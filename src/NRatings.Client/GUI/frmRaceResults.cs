using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NRatings.Client.Business;
using Race = NRatings.Client.Domain.Race;
using RaceResult = NRatings.Client.Domain.RaceResult;

namespace NRatings.Client.GUI
{
    public partial class frmRaceResults : frmBase
    {
        private RRDataFetcher rdf;

        private Race race;
        

        public frmRaceResults(Race race)
        {
            InitializeComponent();
       
            this.rdf = new RRDataFetcher();

            string title;

            if (race.RaceName != null)
                title = race.RaceName + " (" + race.Track.Name + ")";
            else
                title = race.Track.Name;

            this.lblRace.Text = race.RaceDate.ToShortDateString() + ", " + title;


            Race r = Task.Run(() => this.rdf.GetRaceDetailsAsync(race)).Result;
            List<RaceResult> raceResults = (from rr in r.RaceResults
                                            orderby rr.FinishPosition ascending
                                            select rr).ToList();

            this.bsRaceResults.DataSource = raceResults;

            this.race = r;

            if (this.race.LoopDatas == null || this.race.LoopDatas.Count == 0)
                this.butLoopData.Enabled = false;

            if (this.race.PitStopDatas == null || this.race.PitStopDatas.Count == 0)
                this.butPitStopData.Enabled = false;

        }

        private void frmRaceResults_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.dgResults.AutoResizeColumns();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLoopData_Click(object sender, EventArgs e)
        {
            frmLoopData fLoopdata = new frmLoopData(this.race);
            fLoopdata.ShowDialog();
        }

        private void butPitStopData_Click(object sender, EventArgs e)
        {
            frmPitStopData fPitStopData = new frmPitStopData(this.race);
            fPitStopData.ShowDialog();
        }
    }
}