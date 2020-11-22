using System;
using System.Collections.Generic;
using System.IO;

namespace NRatings.Client.Domain
{
    public class Mod
    {

        private String name;
        private String path;
        private List<Roster> rosters;
        private NR2003Instance nr2003Instance;

       
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public List<Roster> Rosters
        {
            get { return this.rosters; }
            set { this.rosters = value; }
        }

        public NR2003Instance NR2003Instance
        {
            get { return this.nr2003Instance; }
            set { this.nr2003Instance = value; }
        }

        public void LoadRosters()
        {
            
            List<Roster> rosterList = new List<Roster>();

            if (this.path != null)
            {
                String carPath = this.path + @"\cars";

                if (Directory.Exists(carPath))
                {

                    String[] rosterFiles = Directory.GetFiles(carPath, "*.lst");

                    Roster allCars = new Roster();
                    allCars.Name = "<All>";
                    allCars.Mod = this;

                    rosterList.Add(allCars);

                    foreach (string s in rosterFiles)
                    {
                        Roster r = new Roster();
                        r.FullPath = s;
                        r.Name = s.Substring(s.LastIndexOf(@"\") + 1);
                        r.Mod = this;
                        rosterList.Add(r);
                    }

                }
            }

            this.rosters = rosterList;
        }


        public override String ToString()
        {
            return this.name;
        }
    }
}
