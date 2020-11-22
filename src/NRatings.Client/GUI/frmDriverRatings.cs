using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;
using TrackType = NRatings.Client.Domain.TrackType;

namespace NRatings.Client.GUI
{
    public partial class frmDriverRatings : frmBase
    {
        private Dictionary<string, List<DriverStats>> driverStatsByType;
        private List<TrackType> trackTypes;
        
        public frmDriverRatings(RealDriverCollection realDriverCollection)
        {
            InitializeComponent();

            this.MaximizeBox = true;

            //string title;

            //if (race.RaceName != null)
            //    title = race.RaceName + " (" + race.Track.Name + ")";
            //else
            //    title = race.Track.Name;

            //this.lblRace.Text = "LoopData for " + race.RaceDate.ToShortDateString() + ", " + title;

            this.CreateRatingsColumns();
            this.bsRealDrivers.DataSource = realDriverCollection;         
        }

        private void CreateRatingsColumns()
        {
            foreach (string ratingsName in Ratings.GetRatingsList().Keys)
            {
                this.dgRealDrivers.Columns.Add(ratingsName + "TextBoxColumn", Ratings.GetRatingsList()[ratingsName].Group + "_" + Ratings.GetRatingsList()[ratingsName].Name);
            }
        }

        private void MapRatingsToColumns()
        {
            foreach (DataGridViewRow row in this.dgRealDrivers.Rows)
            {
                Ratings ratings = ((RealDriver)row.DataBoundItem).Ratings;

                foreach (string ratingsName in Ratings.GetRatingsList().Keys)
                {
                    row.Cells[ratingsName + "TextBoxColumn"].Value = ratings.RatingsList[ratingsName].ToString();
                }
            }
        }

        private void frmDriverRatings_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = this.Size;
            //this.MinimumSize = this.Size;

            this.dgRealDrivers.AutoResizeColumns();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRealDrivers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.MapRatingsToColumns();
        }

    }
}