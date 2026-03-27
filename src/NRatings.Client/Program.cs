using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Auxiliary.Auth;
using NRatings.Client.Auxiliary.Auth.CustomUri;
using NRatings.Client.Auxiliary.Auth.Loopback;
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
        static void Main(string[] args)
        {
            // If launched with a nratings:// URI, this is a callback from the browser
            if (args.Length == 1 && args[0].StartsWith("nratings://", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    CallbackPipe.ForwardCallback(args[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Login callback could not be delivered:\n{ex.Message}", "NRatings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return; // Exit this instance — it was just a relay
            }

            try
            {
                // Normal startup
                UriSchemeRegistrar.EnsureRegistered();

                UserSettingsManager.CreateFoldersIfNeeded();

                UserSettings = UserSettings.Read(); //READ THE USERSETTINGS FIRST

                if (UserSettings == null)
                    UserSettings = new UserSettings();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (HttpServer = new AuthHttpServer())
                {
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