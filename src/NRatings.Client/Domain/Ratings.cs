using System;
using System.Collections.Generic;
using System.ComponentModel;
using NRatings.Client.Auxiliary;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class Ratings : ICloneable, IEquatable<Ratings>
    {
        private Dictionary<string, Rating> mRatingsList;

        public Dictionary<string, Rating> RatingsList
        {
            get { return this.mRatingsList; }
        }

        [field: NonSerialized] //MUST BE NONSERIALIZED IN ORDER TO ALLOW SERIALIZATION OF RATINGS FOR CLONING
        public event EventHandler Changed;
       
        public Ratings()
        {

            this.mRatingsList = Ratings.GetRatingsList();
            
            foreach (Rating rating in this.mRatingsList.Values)
            {
                rating.PropertyChanged += new PropertyChangedEventHandler(rating_PropertyChanged);
            }

        }

        public Rating GetRating(string key)
        {
            return this.mRatingsList[key];
        }

        
        private void rating_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnChanged(e);
        }


        private void OnChanged(EventArgs e)
        {
            if (this.Changed != null)
                this.Changed(this, e);
        }

        public static Dictionary<string, Rating> GetRatingsList()
        {
            Dictionary<string, Rating> list = new Dictionary<string, Rating>();
            list.Add("dr_aggr", new Rating("dr_aggr", "Driver", "Aggression"));
            list.Add("dr_cons", new Rating("dr_cons", "Driver", "Consistency"));
            list.Add("dr_fin", new Rating("dr_fin", "Driver", "Finishing"));
            list.Add("dr_qual", new Rating("dr_qual", "Driver", "Qualifying"));
            list.Add("dr_rc", new Rating("dr_rc", "Driver", "Road Course"));
            list.Add("dr_st", new Rating("dr_st", "Driver", "Short Track"));
            list.Add("dr_sw", new Rating("dr_sw", "Driver", "Speedway"));
            list.Add("dr_ss", new Rating("dr_ss", "Driver", "Super Speedway"));
            list.Add("veh_aero", new Rating("veh_aero", "Vehicle", "Aerodynamics"));
            list.Add("veh_chas", new Rating("veh_chas", "Vehicle", "Chassis"));
            list.Add("veh_eng", new Rating("veh_eng", "Vehicle", "Engine"));
            list.Add("veh_rel", new Rating("veh_rel", "Vehicle", "Reliability"));
            list.Add("pc_cons", new Rating("pc_cons", "PitCrew", "Consistency"));
            list.Add("pc_spe", new Rating("pc_spe", "PitCrew", "Speed"));
            list.Add("pc_strat", new Rating("pc_strat", "PitCrew", "Strategy"));

            return list;
        }




        #region ICloneable Members

        public object Clone()
        {
            Ratings clone = Helper.Clone<Ratings>(this);

            foreach (Rating rating in clone.RatingsList.Values)
            {
                rating.PropertyChanged += new PropertyChangedEventHandler(clone.rating_PropertyChanged); //AFTER CLONING, WE NEED TO REATTACH AN EVENTHANDLER FOR EACH INDIVIDUAL RATING
            }

            return (Ratings)clone;
        }

        #endregion

        
        #region IEquatable<Ratings> Members

        public bool Equals(Ratings other)
        {
            if (other == null)
                return false;
            else
            {
                bool equals = true;

                foreach (var item in this.RatingsList)
                {
                    if (equals == true)
                    {
                        Rating r1 = item.Value;
                        Rating r2 = other.RatingsList[item.Key];

                        if ((r1 == null && r2 != null) || (r1 != null && r2 == null))
                            equals = false;
                        else if ((r1 != null) && (r2 != null) && !r1.Equals(r2))
                            equals = false;
                    }
                }

                return equals;
            }
        
        }

        #endregion
    }
}
