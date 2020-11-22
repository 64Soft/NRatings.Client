using System;
using System.IO;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain;
using NRatings.Client.GUI;

namespace NRatings.Client
{
    static class Program
    {
        public static UserSettings userSettings;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserSettingsManager.CreateFoldersIfNeeded();

            userSettings = UserSettings.Read(); //READ THE USERSETTINGS FIRST

            if (userSettings == null)
                userSettings = new UserSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmNR2003Ratings());
        }

    }
}