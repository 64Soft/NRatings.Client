using System.Windows.Forms;
using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class RatingsGroup : UserControl
    {
        private Ratings mRatings;

        public RatingsGroup()
        {
            InitializeComponent();
        }

        public Ratings Ratings
        {

            get { return this.mRatings; }
            set
            {
                this.TrackChanges(false); //DO NOT FIRE EVENTS WHEN SETTING THE RATINGS PROPERTY OF THE CONTROL

                this.mRatings = value;

                if (this.mRatings != null)
                {
                    this.riDriverAggression.Rating = this.mRatings.GetRating("dr_aggr");
                    this.riDriverConsistency.Rating = this.mRatings.GetRating("dr_cons");
                    this.riDriverFinishing.Rating = this.mRatings.GetRating("dr_fin");
                    this.riDriverQualifying.Rating = this.mRatings.GetRating("dr_qual");
                    this.riDriverRoadCourse.Rating = this.mRatings.GetRating("dr_rc");
                    this.riDriverShortTrack.Rating = this.mRatings.GetRating("dr_st");
                    this.riDriverSpeedway.Rating = this.mRatings.GetRating("dr_sw");
                    this.riDriverSuperSpeedway.Rating = this.mRatings.GetRating("dr_ss");
                    this.riVehicleAero.Rating = this.mRatings.GetRating("veh_aero");
                    this.riVehicleChassis.Rating = this.mRatings.GetRating("veh_chas");
                    this.riVehicleEngine.Rating = this.mRatings.GetRating("veh_eng");
                    this.riVehicleReliability.Rating = this.mRatings.GetRating("veh_rel");
                    this.riPitcrewConsistency.Rating = this.mRatings.GetRating("pc_cons");
                    this.riPitcrewSpeed.Rating = this.mRatings.GetRating("pc_spe");
                    this.riPitcrewStrategy.Rating = this.mRatings.GetRating("pc_strat");
                }

                this.TrackChanges(true);
            }
        }

        public void EnableControls(bool enable)
        {
            foreach (Control ctrl in grpRatings.Controls)
            {
                if (ctrl.GetType() == typeof(RatingsItem))
                {
                    RatingsItem ri = (RatingsItem)ctrl;
                    ri.EnableControls(enable);
                }

            }

        }

        private void TrackChanges(bool track)
        {
            foreach (Control ctrl in grpRatings.Controls)
            {
                if (ctrl.GetType() == typeof(RatingsItem))
                {
                    RatingsItem ri = (RatingsItem)ctrl;
                    ri.TrackChanges = track;
                }

            }

        }

    }
}
