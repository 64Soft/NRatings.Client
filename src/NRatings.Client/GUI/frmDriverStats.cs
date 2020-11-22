using System;
using System.Collections.Generic;
using NRatings.Client.Domain;
using TrackType = NRatings.Client.Domain.TrackType;

namespace NRatings.Client.GUI
{
    public partial class frmDriverStats : frmBase
    {

        private Dictionary<string, List<DriverStats>> driverStatsByType;
        private List<TrackType> trackTypes;
        
        public frmDriverStats(Dictionary<string, List<DriverStats>> driverStatsByType, List<TrackType> trackTypes)
        {
            InitializeComponent();

            this.MaximizeBox = true;

            //string title;

            //if (race.RaceName != null)
            //    title = race.RaceName + " (" + race.Track.Name + ")";
            //else
            //    title = race.Track.Name;

            //this.lblRace.Text = "LoopData for " + race.RaceDate.ToShortDateString() + ", " + title;

            this.driverStatsByType = driverStatsByType;

            this.trackTypes = new List<TrackType>();
            this.trackTypes.Add(new TrackType { Id = "ALL", Name = "All Tracktypes" });

            foreach (TrackType tt in trackTypes)
            {
                this.trackTypes.Add(new TrackType { Id = tt.Id, Name = tt.Name });
            }


            this.bsTrackTypes.DataSource = this.trackTypes;

        }

        private void frmDriverStats_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = this.Size;
            //this.MinimumSize = this.Size;

            this.dgDriverStats.AutoResizeColumns();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsTrackTypes_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                string trackTypeId = (this.bsTrackTypes.Current as TrackType).Id;

                List<DriverStats> stats = driverStatsByType[trackTypeId];
                this.bsDriverStats.DataSource = stats;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                this.bsDriverStats.Clear();
            }
        }
    }
}