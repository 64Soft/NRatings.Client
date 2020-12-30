using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0.OidcClient;
using NRatings.Client.WebView2;

namespace NRatings.Client.Domain
{
    public static class UserManager
    {
        private static ClaimsIdentity user;

        public static string UserName => user?.FindFirst("name")?.Value;
        public static string Email => user?.FindFirst("email")?.Value;


        public static async Task<UserLoginResult> LoginAsync()
        {
            //first try to use a possible refresh token to obtain a new access token
            await RefreshAccessToken();

            if(HasValidAccessToken())
                return new UserLoginResult(true);


            //if previous step did not succeed, go through the login process
            if (await WebView2Install.EnsureWebView2InstalledAsync())
            {
                var loginResult = await GetAuth0Client().LoginAsync(extraParameters: GetAuth0Params());

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

            return new UserLoginResult(false, "Could not log you in");
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

        public static async Task LogOutAsync()
        {
            user = null;
            Program.UserSettings.ClearAccessToken();
            Program.UserSettings.ClearRefreshToken();

            await GetAuth0Client().LogoutAsync();
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

                    await SetUserFromAccessTokenAsync();
                }
            }
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

        private static Auth0Client GetAuth0Client()
        {
            var clientOptions = new Auth0ClientOptions
            {
                Domain = ConfigurationManager.AppSettings["Auth0Domain"],
                ClientId = ConfigurationManager.AppSettings["Auth0ClientId"],
                Browser = new WebView2Browser()
            };

            var client = new Auth0Client(clientOptions);
            clientOptions.PostLogoutRedirectUri = clientOptions.RedirectUri;

            return client;
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
