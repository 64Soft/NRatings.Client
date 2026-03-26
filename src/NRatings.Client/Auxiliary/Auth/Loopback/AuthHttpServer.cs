using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace NRatings.Client.Auxiliary.Auth.Loopback
{
    public class AuthHttpServer : IDisposable
    {
        private string serverUri = "http://127.0.0.1/"; //todo: manage selected port
        private HttpListener http;

        public AuthHttpServer()
        {
            try
            {
                this.http = new HttpListener();
                this.http.Prefixes.Add(serverUri);
                this.http.Start();
            }
            catch (Exception ex)
            {
                this.http = null;
                Debug.WriteLine(ex);
            }
        }

        public bool IsRunning() => this.http?.IsListening ?? false;

        public async Task<HttpListenerContext> GetHttpListenerContextAsync()
        {
            if (this.http == null)
                throw new Exception("Local authentication server not started");

            return await this.http.GetContextAsync();
        }

        public void Dispose()
        {
            this.http?.Stop();
        }
    }
}
