using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Microsoft.Web.WebView2.Core;

namespace NRatings.Client.WebView2
{
    public static class WebView2Install
    {
        public static async Task<bool> EnsureWebView2InstalledAsync()
        {
            if (string.IsNullOrWhiteSpace(GetWebView2Version()))
            {
                var result = MessageBox.Show(
                    "You are missing the Edge WebView2 Runtime component for the login process to work. This component will now be downloaded and you will be prompted to install it. You will only need to do this once. You'll need administrator privileges to install it.",
                    "Extra component required", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if(result == DialogResult.OK)
                {
                    return await InstallWebView2RuntimeAsync();
                }

                return false;
            }

            return true;
        }

        private static string GetWebView2Version()
        {
            try
            {
                return CoreWebView2Environment.GetAvailableBrowserVersionString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static async Task<bool> InstallWebView2RuntimeAsync()
        {
            var tempFileName = "MicrosoftEdgeWebview2Setup.exe";

            var downloadedFilePath = await "https://go.microsoft.com/fwlink/p/?LinkId=2124703".DownloadFileAsync(Path.GetTempPath(), tempFileName);

            var installCommand = Path.Combine(downloadedFilePath);
            var process = Process.Start(installCommand);
            
            if(process != null)
            {
                process.WaitForExit();
                return process.ExitCode == 0;
            }

            return false;
        }
    }
}
