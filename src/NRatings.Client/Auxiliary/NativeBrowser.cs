using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using IdentityModel.OidcClient.Browser;

namespace NRatings.Client.Auxiliary
{
    public class NativeBrowser : IBrowser
    {
        private string redirectBaseUri = ConfigurationManager.AppSettings["AuthNativeBrowserRedirectBaseUri"];
        
        public Form CallingForm { get; set; }
        public string StartUrl { get; private set; }
        
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            this.StartUrl = options.StartUrl;

            var redirectUri = this.StartUrl.Contains("logout?")
                ? this.redirectBaseUri.AppendPathSegment("logout")
                : this.redirectBaseUri.AppendPathSegment("login");

            // Opens request in the browser.
            Process.Start(options.StartUrl);

            // Waits for the OAuth authorization response.
            var context = await Program.HttpServer.GetHttpListenerContextAsync();
            var authResponse = context.Request.Url.ToString();

            this.CallingForm?.Activate();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            response.RedirectLocation = redirectUri;
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
