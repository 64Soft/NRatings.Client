using System.Reflection;
using Microsoft.Win32;

namespace NRatings.Client.Auxiliary.Auth.CustomUri
{
    public static class UriSchemeRegistrar
    {
        private const string SchemeName = "nratings";

        public static void EnsureRegistered()
        {
            var exePath = Assembly.GetExecutingAssembly().Location;
            var root = $@"Software\Classes\{SchemeName}";

            Registry.SetValue($@"HKEY_CURRENT_USER\{root}","", $"URL:{SchemeName} Protocol");
            Registry.SetValue($@"HKEY_CURRENT_USER\{root}", "URL Protocol", "");
            Registry.SetValue($@"HKEY_CURRENT_USER\{root}\shell\open\command", "", $"\"{exePath}\" \"%1\"");
        }

        public static void Unregister()
        {
            Registry.CurrentUser.DeleteSubKeyTree($@"Software\Classes\{SchemeName}", throwOnMissingSubKey: false);
        }
    }
}