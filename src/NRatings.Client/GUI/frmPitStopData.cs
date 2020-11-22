using System;
using System.Collections.Generic;
using System.Linq;
using NRatings.Client.Business;
using PitStopData = NRatings.Client.Domain.PitStopData;
using Race = NRatings.Client.Domain.Race;

namespace NRatings.Client.GUI
{
    public partial class frmPitStopData : frmBase
    {
        public frmPitStopData(Race race)
        {
            InitializeComponent();

            string title;

            if (race.RaceName != null)
                title = race.RaceName + " (" + race.Track.Name + ")";
            else
                title = race.Track.Name;

            this.lblRace.Text = "PitStopData for " + race.RaceDate.ToShortDateString() + ", " + title;


            List<PitStopData> PitStopData = (from pd in race.PitStopDatas
                                          orderby pd.AverageTime ascending
                                          select pd).ToList();

            this.bsPitStopData.DataSource = PitStopData;

        }

        private void frmPitStopData_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.dgPitStopData.AutoResizeColumns();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}