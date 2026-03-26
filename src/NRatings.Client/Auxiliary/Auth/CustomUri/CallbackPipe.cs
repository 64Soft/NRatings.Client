using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NRatings.Client.Auxiliary.Auth.CustomUri
{
    public class CallbackPipe : IDisposable
    {
        private const string PipeName = "NRatingsAuthCallback";
        private NamedPipeServerStream _server;

        // Called by the main instance: start listening for a callback URL
        public async Task<string> WaitForCallbackAsync(CancellationToken cancellationToken)
        {
            _server = new NamedPipeServerStream(
                PipeName, PipeDirection.In, 1,
                PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            await Task.Factory.FromAsync(_server.BeginWaitForConnection,
                _server.EndWaitForConnection, null);

            cancellationToken.ThrowIfCancellationRequested();

            var buffer = new byte[4096];
            var bytesRead = await _server.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        // Called by the callback instance: forward the URL to the main instance
        public static void ForwardCallback(string url)
        {
            using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
            {
                client.Connect(timeout: 3000);
                var bytes = Encoding.UTF8.GetBytes(url);
                client.Write(bytes, 0, bytes.Length);
            }
        }

        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}