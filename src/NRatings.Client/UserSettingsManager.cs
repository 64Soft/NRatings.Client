using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NRatings.Client
{
    public static class UserSettingsManager
    {
        private static readonly string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string NRatingsFolder = @"NRatings";
        private const string MyFormulasFolder = @"MyFormulas";
        

        public static string GetApplicationPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetSettingsPath()
        {
            CreateFoldersIfNeeded();

            return Path.Combine(myDocsPath, NRatingsFolder);
        }

        public static string GetMyFormulasPath()
        {

            CreateFoldersIfNeeded();

            return Path.Combine(myDocsPath, NRatingsFolder, MyFormulasFolder);
        }

        public static void CreateFoldersIfNeeded()
        {
            if (!Directory.Exists(Path.Combine(myDocsPath, NRatingsFolder)))
            {
                Directory.CreateDirectory(Path.Combine(myDocsPath, NRatingsFolder));
            }

            if (!Directory.Exists(Path.Combine(myDocsPath, NRatingsFolder, MyFormulasFolder)))
            {
                Directory.CreateDirectory(Path.Combine(myDocsPath, NRatingsFolder, MyFormulasFolder));
            }
        }
    }
}
