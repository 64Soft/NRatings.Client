using System;
using System.ComponentModel;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class Rating : INotifyPropertyChanged, IEquatable<Rating>
    {

        private string mKey;
        private string mGroup;
        private string mName;

        private int mMin = 0;
        private int mMax = 0;

        private double mMean = 0.0;
        private double mDev = 0.0;

        #region INotifyPropertyChanged Members

        [field: NonSerialized] //MUST BE NONSERIALIZED IN ORDER TO ALLOW SERIALIZATION OF RATINGS FOR CLONING
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public Rating(string key, string group, string name)
        {
            this.mKey = key;
            this.mGroup = group;
            this.mName = name;
        }

        public string Key
        {
            get { return this.mKey; }
        }

        public string Group
        {
            get { return this.mGroup; }
        }

        public string Name
        {
            get { return this.mName; }
        }

        public int Min
        {
            get { return this.mMin; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > 100)
                    value = 100;

                if (this.mMin != value)
                {
                    this.mMin = value;

                    if (this.mMax < value)
                        this.mMax = value;

                    this.ComputeMeanAndDev();
                    this.OnPropertyChanged("Min");
                }
            }
        }

        public int Max
        {
            get { return this.mMax; }
            set
            {
                if (value < 0)
                    value = 0;

                if (value > 100)
                    value = 100;

                if (this.mMax != value)
                {
                    this.mMax = value;

                    if (this.mMin > value)
                        this.mMin = value;

                    this.ComputeMeanAndDev();
                    this.OnPropertyChanged("Max");
                }
            }
        }

        public double Mean
        {

            get { return this.mMean; }
            set
            {
                if (this.mMean != value)
                {
                    this.mMean = value;
                    this.ComputeMinAndMax();
                    this.OnPropertyChanged("Mean");
                }

            }
        }

        public double Dev
        {

            get { return this.mDev; }
            set
            {
                if (this.mDev != value)
                {
                    this.mDev = value;
                    this.ComputeMinAndMax();
                    this.OnPropertyChanged("Dev");
                }

            }
        }


        private void ComputeMeanAndDev()
        {
            this.mMean = (GetAverage(this.mMin, this.mMax)) / 50.0;
            this.mDev = (this.mMax - this.mMin) / 200.0;
        }

        private void ComputeMinAndMax()
        {
            int min = Convert.ToInt32((this.mMean * 50) - (this.mDev * 100));
            int max = Convert.ToInt32((this.mMean * 50) + (this.mDev * 100));

            if (min < 0)
                min = 0;

            if (max > 100)
                max = 100;

            this.mMin = min;
            this.mMax = max;
        }


        private double GetAverage(int x, int y)
        {
            return (x + y) / 2.0;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.mMin.ToString() + " - " + this.mMax.ToString();
        }

        #region IEquatable<Rating> Members

        public bool Equals(Rating other)
        {
            if (other == null)
                return false;
            else if (this.Min == other.Min && this.Max == other.Max)
                return true;
            else
                return false;
        }

        #endregion
    }
}
