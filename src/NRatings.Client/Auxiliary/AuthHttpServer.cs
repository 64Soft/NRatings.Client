using System;
using System.Collections.Generic;
using System.Configuration;
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
            this.http = new HttpListener();
            this.http.Prefixes.Add(serverUri);
            this.http.Start();
        }

        public async Task<HttpListenerContext> GetHttpListenerContextAsync()
        {
            return await this.http.GetContextAsync();
        }

        public void Dispose()
        {
            this.http.Stop();
        }
    }
}
