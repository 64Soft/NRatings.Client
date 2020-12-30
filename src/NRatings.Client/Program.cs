using System;
using System.Net;
using System.Windows.Forms;
using NRatings.Client.Domain;
using NRatings.Client.GUI;

namespace NRatings.Client
{
    static class Program
    {
        public static UserSettings UserSettings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
}