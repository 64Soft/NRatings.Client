using System;
using System.Collections.Generic;
using System.Linq;
using NRatings.Client.Business;
using LoopData = NRatings.Client.Domain.LoopData;
using Race = NRatings.Client.Domain.Race;

namespace NRatings.Client.GUI
{
    public partial class frmLoopData : frmBase
    {
        public frmLoopData(Race race)
        {
            InitializeComponent();

            string title;

            if (race.RaceName != null)
                title = race.RaceName + " (" + race.Track.Name + ")";
            else
                title = race.Track.Name;

            this.lblRace.Text = "LoopData for " + race.RaceDate.ToShortDateString() + ", " + title;


            List<LoopData> loopData = (from ld in race.LoopDatas
                                       orderby ld.Rating descending
                                       select ld).ToList();

            this.bsLoopData.DataSource = loopData;

        }

        private void frmLoopData_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.dgLoopData.AutoResizeColumns();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}