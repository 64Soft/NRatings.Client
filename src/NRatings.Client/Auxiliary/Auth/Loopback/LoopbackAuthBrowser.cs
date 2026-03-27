using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Duende.IdentityModel.OidcClient.Browser;
using Flurl;

namespace NRatings.Client.Auxiliary.Auth.Loopback
{
    public class LoopbackAuthBrowser : IAuthBrowser
    {
        private readonly string postLoopbackRedirectBaseUri = ConfigurationManager.AppSettings["AuthNativeBrowserRedirectBaseUri"];

        public string OidcLoginRedirectUri => Program.HttpServer.RedirectUri;
        public string OidcLogoutRedirectUri => Program.HttpServer.RedirectUri;

        public Form CallingForm { get; set; }
        public string StartUrl { get; private set; }
        
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            this.StartUrl = options.StartUrl;

            var postLoopbackRedirectUri = this.StartUrl.Contains("logout?")
                ? this.postLoopbackRedirectBaseUri.AppendPathSegment("logout")
                : this.postLoopbackRedirectBaseUri.AppendPathSegment("login");

            // Opens request in the browser.
            Process.Start(options.StartUrl);

            // Waits for the OAuth authorization response.
            var context = await Program.HttpServer.GetHttpListenerContextAsync();
            var authResponse = context.Request.Url.ToString();

            this.CallingForm?.Activate();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            response.RedirectLocation = postLoopbackRedirectUri;
            response.StatusCode = 302;
            var responseString = @"<html><body>You are being redirected...</body></html>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            using (var output = response.OutputStream)
            {
                await output.WriteAsync(buffer, 0, buffer.Length);
            }

            return new BrowserResult() { ResultType = BrowserResultType.Success, Response = authResponse };
        }
    }
}
