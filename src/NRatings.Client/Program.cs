using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdentityModel.Client;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain;
using NRatings.Client.GUI;

namespace NRatings.Client
{
    static class Program
    {
        public static UserSettings UserSettings;
        public const string CustomUriScheme = "eu.64soft.nratings";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static async Task Main(string[] args)
        {
            if (args.Any())
            {
                await ProcessCallback(args[0]);
            }
            else
            {
                await Run();
            }

        }

        private static async Task Run()
        {
            try
            {
                new RegistryConfig(CustomUriScheme).Configure();

                UserSettingsManager.CreateFoldersIfNeeded();

                UserSettings = UserSettings.Read(); //READ THE USERSETTINGS FIRST

                if (UserSettings == null)
                    UserSettings = new UserSettings();

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new frmNR2003Ratings());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task ProcessCallback(string args)
        {
            var lines = new List<string> { "Callback received" };
            
            var response = new AuthorizeResponse(args);
            if (!String.IsNullOrWhiteSpace(response.State))
            {
                lines.Add($"Found state: {response.State}");
                var callbackManager = new CallbackManager(response.State);
                await callbackManager.RunClient(args);
            }
            else
            {
                lines.Add("Error: no state on response");
            }
        }

    }
}