using System;
using System.Collections.Generic;
using System.IO;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class NR2003Instance
    {
        private string name;
        private string path;
        private bool isDefault = false;

        [NonSerialized]
        private List<Mod> mods;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public bool IsDefault
        {
            get { return this.isDefault; }
            set { this.isDefault = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public List<Mod> Mods
        {
            get { return this.mods; }
            set { this.mods = value; }
        }

        public void LoadMods()
        {
            
            List<Mod> modList = new List<Mod>();

            if (this.path != null)
            {
                if (Directory.Exists(this.path + @"\series"))
                {
                    String[] series = Directory.GetDirectories(this.path + @"\series");

                    Mod blankMod = new Mod();
                    blankMod.Name = "";
                    blankMod.NR2003Instance = this;

                    modList.Add(blankMod);

                    foreach (String s in series)
                    {
                        Mod mod = new Mod();
                        mod.Path = s;
                        mod.Name = s.Substring(s.LastIndexOf(@"\") + 1);
                        mod.NR2003Instance = this;
                        modList.Add(mod);
                    }
                }
            }

            this.mods = modList;

        }


        public override string ToString()
        {
            if (this.name != null && !this.name.Equals(string.Empty))
            {
                return this.name;
            }
            else if (this.path != null && !this.path.Equals(string.Empty))
            {
                return this.path;
            }
            else
            {
                return "no info";
            }
        }
    }
}
