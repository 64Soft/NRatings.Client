using System;
using System.Windows.Forms;
using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class RatingsItem : UserControl
    {

        private Rating mRating;
        private bool mEnabled = false;
        private bool mTrackChanges = false;
       
        public RatingsItem()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get { return this.lblRatingsLabel.Text; }
            set { this.lblRatingsLabel.Text = value; }
        }

        public bool TrackChanges
        {
            get { return this.mTrackChanges; }
            set { this.mTrackChanges = value; }
        }

        
        public Rating Rating
        {
            get { return this.mRating; }
            set
            {
                if (value != null)
                {
                    this.mRating = value;
                    this.udRatingsMin.Minimum = 0;
                    this.udRatingsMin.Maximum = 100;
                    this.udRatingsMax.Minimum = 0;
                    this.udRatingsMax.Maximum = 100;

                
                    this.udRatingsMin.Value = value.Min;
                    this.udRatingsMax.Value = value.Max;
                }
                
            }
        }

       
        public void EnableControls(bool enable)
        {
            this.mEnabled = enable;
            this.udRatingsMin.Enabled = enable;
            this.udRatingsMax.Enabled = enable;
        }

        private void udRatingsMin_ValueChanged(object sender, EventArgs e)
        {
            if (this.mTrackChanges == true)
            {
                this.udRatingsMax.Minimum = udRatingsMin.Value;
                this.mRating.Min = Convert.ToInt32(udRatingsMin.Value);
            }
        }

        private void udRatingsMax_ValueChanged(object sender, EventArgs e)
        {
            if (this.mTrackChanges == true)
            {
                this.udRatingsMin.Maximum = udRatingsMax.Value;
                this.mRating.Max = Convert.ToInt32(udRatingsMax.Value);
            }
        }

    }
}
