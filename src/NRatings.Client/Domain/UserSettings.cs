using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using IdentityModel.OidcClient;
using NRatings.Client.Auxiliary;
using NRatings.Client.GUI;
using RandomStringCreator;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class UserSettings
    {
        private static string filePath = Path.Combine(UserSettingsManager.GetSettingsPath(), @"usersettings.xml");

        public string DefaultFormula { get; set; }
        public List<NR2003Instance> NR2003Instances { get; set; }

        public string AuthSessionToken { get; set; }
        public string AccesToken { get; set; }
        public DateTime? AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        
        public UserSettings()
        {
            this.DefaultFormula = String.Empty;
            this.NR2003Instances = new List<NR2003Instance>();
        }

        public void SetAuthSessionToken()
        {
            this.AuthSessionToken = new StringCreator().Get(10);

            this.Save();
        }

        public void ClearAuthSessionToken()
        {
            this.AuthSessionToken = null;

            this.Save();
        }

        public void SaveAccessToken(string accessToken, DateTime accessTokenExpiration)
        {
            this.AccesToken = accessToken;
            this.AccessTokenExpiration = accessTokenExpiration;

            this.Save();
        }

        public void ClearAccessToken()
        {
            this.AccesToken = null;
            this.AccessTokenExpiration = null;

            this.Save();
        }

        public void SaveRefreshToken(string refreshToken)
        {
            this.RefreshToken = refreshToken;

            this.Save();
        }

        public void ClearRefreshToken()
        {
            this.RefreshToken = null;

            this.Save();
        }

        public void Save()
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(UserSettings));
                TextWriter w = new StreamWriter(filePath);
                s.Serialize(w, this);
                w.Close();
            }
            catch (Exception ex)
            {
                frmNR2003Ratings.ShowError(ex.ToString());
            }
            

        }

        public static UserSettings Read()
        {
            XmlSerializer s = new XmlSerializer(typeof(UserSettings));

            try
            {
                if (File.Exists(filePath))
                {
                    TextReader r = new StreamReader(filePath);
                    UserSettings u = (UserSettings)s.Deserialize(r);
                    r.Close();

                    
                    return u;
                }
                else
                {
                    //frmNR2003Ratings.ShowMessage("Settings file not found. Please set the path to your NR2003 folder.", "Settings file not found");
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Helper.Logger.LogError("UserSettings", "Error while reading usersettings: " + ex.ToString());
                return null;
            }

        }
    }
}
