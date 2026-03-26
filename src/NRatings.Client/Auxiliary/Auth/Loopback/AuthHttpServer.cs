using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NRatings.Client.Auxiliary.Auth.Loopback
{
    public class AuthHttpServer : IDisposable
    {
        private HttpListener http;

        /// <summary>
        /// The port the server is actually listening on, or null if startup failed.
        /// </summary>
        public int? Port { get; private set; }

        /// <summary>
        /// The loopback redirect URI including the active port.
        /// </summary>
        public string RedirectUri => Port.HasValue ? $"http://127.0.0.1:{Port.Value}/" : null;

        public AuthHttpServer()
        {
            var portsConfig = ConfigurationManager.AppSettings["AuthLoopbackPorts"];
            if (string.IsNullOrWhiteSpace(portsConfig))
                return;

            var ports = portsConfig
                .Split(',')
                .Select(p => p.Trim())
                .Where(p => int.TryParse(p, out _))
                .Select(int.Parse);

            foreach (var port in ports)
            {
                try
                {
                    var listener = new HttpListener();
                    listener.Prefixes.Add($"http://127.0.0.1:{port}/");
                    listener.Start();

                    this.http = listener;
                    this.Port = port;
                    Debug.WriteLine($"Auth HTTP server started on port {port}");
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Could not start auth HTTP server on port {port}: {ex.Message}");
                }
            }

            Debug.WriteLine("Auth HTTP server could not start on any configured port.");
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
