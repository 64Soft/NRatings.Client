using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth0.OidcClient;
using NRatings.Client.Auxiliary;

namespace NRatings.Client.Domain
{
    public static class UserManager
    {
        private static ClaimsIdentity user;
        private static NativeBrowser nativeBrowser = new NativeBrowser();
        private static Auth0Client auth0Client;
        private static bool loginOngoing;

        public static string UserName => user?.FindFirst("name")?.Value;
        public static string Email => user?.FindFirst("email")?.Value;


        public static async Task<UserLoginResult> LoginAsync(Form callingForm = null)
        {
            //first try to use a possible refresh token to obtain a new access token
            await RefreshAccessToken();

            if(HasValidAccessToken())
                return new UserLoginResult(true);

            //if user previously started login process but closed browser, an existing NativeBrowser object is still awaiting the result. If that is the case, just reopen the browser with the startUrl
            if (loginOngoing)
                Process.Start(nativeBrowser.StartUrl);
            else
            {
                loginOngoing = true;
                var loginResult = await GetAuth0Client(callingForm).LoginAsync(extraParameters: GetAuth0Params());
                loginOngoing = false;

                if (!loginResult.IsError)
                {
                    if (loginResult.User?.Identity is ClaimsIdentity identity)
                    {
                        user = identity;
                        Program.UserSettings.SaveAccessToken(loginResult.AccessToken, loginResult.AccessTokenExpiration);
                        Program.UserSettings.SaveRefreshToken(loginResult.RefreshToken);

                        return new UserLoginResult(true);
                    }
                }
                else
                {
                    return new UserLoginResult(false, loginResult.Error);
                }
            }

            return null;
        }

        
        public static async Task<bool> IsLoggedInAsync()
        {
            if (user == null)
                await RefreshAccessToken();

            return user != null;
        }

        public static bool? IsEmailVerified()
        {
            if (bool.TryParse(user?.FindFirst("email_verified")?.Value, out var verified))
            {
                return verified;
            }

            return null;
        }

        public static async Task LogOutAsync(Form callingForm = null)
        {
            user = null;
            Program.UserSettings.ClearAccessToken();
            Program.UserSettings.ClearRefreshToken();

            await GetAuth0Client(callingForm).LogoutAsync();
        }

        public static async Task<string> GetUserInfoStringAsync(string propertySeparator = ";")
        {
            await RefreshAccessToken();

            if (user != null)
            {
                var info = $"User: {UserName}{propertySeparator}Email: {Email}{propertySeparator}Email Verified: {IsEmailVerified()}";
                return info;
            }

            return "(You are not logged in)";
        }

        private static async Task RefreshAccessToken()
        {
            if(HasRefreshToken())
            {
                var tokenResult = await GetAuth0Client().RefreshTokenAsync(Program.UserSettings.RefreshToken);
                if (!tokenResult.IsError)
                {
                    Program.UserSettings.SaveAccessToken(tokenResult.AccessToken, tokenResult.AccessTokenExpiration);
                    if (tokenResult.RefreshToken != null)
                        Program.UserSettings.SaveRefreshToken(tokenResult.RefreshToken);
                }
                else
                {
                    //if refresh token resulted in error, clear all tokens to completely to re-initialize the login system
                    user = null;
                    Program.UserSettings.ClearAccessToken();
                    Program.UserSettings.ClearRefreshToken();
                }
            }

            await SetUserFromAccessTokenAsync();
        }

        private static async Task SetUserFromAccessTokenAsync()
        {
            if(HasValidAccessToken())
            {
                var userInfoResult = await GetAuth0Client().GetUserInfoAsync(Program.UserSettings.AccesToken);
                if (!userInfoResult.IsError)
                {
                    user = new ClaimsIdentity(userInfoResult.Claims);
                }
            }
        }

        private static bool HasValidAccessToken()
        {
            return !string.IsNullOrWhiteSpace(Program.UserSettings.AccesToken) && Program.UserSettings.AccessTokenExpiration > DateTime.Now;
        }

        private static bool HasRefreshToken()
        {
            return !string.IsNullOrEmpty(Program.UserSettings.RefreshToken);
        }

        private static Auth0Client GetAuth0Client(Form callingForm = null)
        {
            nativeBrowser.CallingForm = callingForm;

            if (auth0Client == null)
            {
                var clientOptions = new Auth0ClientOptions
                {
                    Domain = ConfigurationManager.AppSettings["Auth0Domain"],
                    ClientId = ConfigurationManager.AppSettings["Auth0ClientId"],
                    Browser = nativeBrowser,
                    RedirectUri = ConfigurationManager.AppSettings["AuthHttpServer"],
                };

                clientOptions.PostLogoutRedirectUri = clientOptions.RedirectUri;
                auth0Client = new Auth0Client(clientOptions);
            }

            return auth0Client;
        }

        private static Dictionary<string, string> GetAuth0Params()
        {
            var auth0Params = new Dictionary<string, string>
            {
                {
                    "audience", ConfigurationManager.AppSettings["Auth0ApiAudience"]
                },

                {
                    "scope", "openid profile email offline_access"
                }
            };

            return auth0Params;
        }
    }
}
