using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using IdentityModel.OidcClient.Browser;

namespace NRatings.Client.Auxiliary.Auth.CustomUri
{
    public class CustomUriAuthBrowser : IAuthBrowser
    {
        private readonly string redirectBaseUri = ConfigurationManager.AppSettings["AuthNativeBrowserRedirectBaseUri"];

        public string OidcLoginRedirectUri => this.redirectBaseUri.AppendPathSegment("login");
        public string OidcLogoutRedirectUri => this.redirectBaseUri.AppendPathSegment("logout").AppendQueryParam("app", "nratings");

        public Form CallingForm { get; set; }
        public string StartUrl { get; private set; }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            using (var pipe = new CallbackPipe())
            {
                this.StartUrl = options.StartUrl;

                var isLogout = this.StartUrl.Contains("logout?");

                // Start listening before opening the browser
                var callbackTask = pipe.WaitForCallbackAsync(cancellationToken);

                // Open Auth0 login in the default system browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = options.StartUrl,
                    UseShellExecute = true
                });

                string callbackUrl;
                try
                {
                    callbackUrl = await callbackTask;
                }
                catch (OperationCanceledException)
                {
                    return new BrowserResult
                    {
                        ResultType = BrowserResultType.UserCancel
                    };
                }

                this.CallingForm?.Activate();

                return new BrowserResult
                {
                    ResultType = BrowserResultType.Success,
                    Response = isLogout ? "" : callbackUrl
                };
            }
        }
    }
}