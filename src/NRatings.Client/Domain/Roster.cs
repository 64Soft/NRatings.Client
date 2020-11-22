using System;
using System.IO;

namespace NRatings.Client.Domain
{
    public class Roster
    {
        private string mName;
        private string mFullPath = null;
        private Mod mod;

        public string Name
        {
            get { return this.mName; }
            set { this.mName = value; }
        }

        public string FullPath
        {
            get { return this.mFullPath; }
            set { this.mFullPath = value; }
        }

        public Mod Mod
        {
            get { return this.mod; }
            set { this.mod = value; }
        }

        public override String ToString()
        {
            return this.mName;
        }

        public string GetRosterContents()
        {
            if (this.mFullPath != null)
            {
                try
                {
                    return File.ReadAllText(this.mFullPath);
                }
                catch (Exception ex)
                {
                    throw ex;   
                }

            }
            else
                return null;
        }
    }
}
