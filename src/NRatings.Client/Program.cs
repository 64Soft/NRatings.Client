using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain;
using NRatings.Client.GUI;

namespace NRatings.Client
{
    static class Program
    {
        public static UserSettings UserSettings;
        public static AuthHttpServer HttpServer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (HttpServer = new AuthHttpServer())
                {
                    if (!HttpServer.IsRunning())
                        MessageBox.Show(
                            $@"NRatings could not start a local http server on {ConfigurationManager.AppSettings["AuthHttpServer"]} to manage authentication calls. You will not be able to fetch racing data.{Environment.NewLine}
Make sure this port is not used by any other application on your PC when you run NRatings.{Environment.NewLine}
You can use TCPView (https://docs.microsoft.com/en-us/sysinternals/downloads/tcpview) to determine which other app is using this port.",
                            "Error starting authentication mechanism", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    UserSettingsManager.CreateFoldersIfNeeded();

                    UserSettings = UserSettings.Read(); //READ THE USERSETTINGS FIRST

                    if (UserSettings == null)
                        UserSettings = new UserSettings();

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new frmNR2003Ratings());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}