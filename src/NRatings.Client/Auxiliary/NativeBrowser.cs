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
        private string callbackUri = ConfigurationManager.AppSettings["AuthNativeBrowserCallbackUri"];
        private string redirectUri = ConfigurationManager.AppSettings["AuthNativeBrowserRedirectBaseUri"].AppendPathSegment("login");
        private Form callingForm;

        public NativeBrowser(Form callingForm)
        {
            this.callingForm = callingForm;
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = new CancellationToken())
        {
            string authResponse = null;

            // Creates an HttpListener to listen for requests on that redirect URI.
            using (var http = new HttpListener())
            {
                http.Prefixes.Add(callbackUri);
                http.Start();
                
                // Opens request in the browser.
                Process.Start(options.StartUrl);

                // Waits for the OAuth authorization response.
                var context = await http.GetContextAsync();
                authResponse = context.Request.Url.ToString();

                if (callingForm != null)
                    callingForm.Activate();

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

                http.Stop();
            }


            return new BrowserResult() { ResultType = BrowserResultType.Success, Response = authResponse };
        }
    }
}
