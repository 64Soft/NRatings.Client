using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NRatings.Client.Auxiliary
{
    public class AuthHttpServer : IDisposable
    {
        private string serverUri = ConfigurationManager.AppSettings["AuthHttpServer"];
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
