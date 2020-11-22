using System;

namespace NRatings.Client.Domain
{
    public class RealDriver : IComparable<RealDriver>
    {
        private string mNumber;
        private string mFirstName;
        private string mLastName;
        private string mFullName;
        private Ratings mRatings;
        private bool mMatchFound = false;

        public string Number
        {
            get { return this.mNumber; }
            set { this.mNumber = value; }
        }

        public string FirstName
        {
            get { return this.mFirstName; }
            set { this.mFirstName = value; }
        }

        public string LastName
        {
            get { return this.mLastName; }
            set { this.mLastName = value; }
        }

        public string FullName
        {
            get { return this.mFullName; }
            set { this.mFullName = value; }
        }

        public Ratings Ratings
        {
            get { return this.mRatings; }
            set { this.mRatings = value; }
        }

        public bool MatchFound
        {
            get { return this.mMatchFound; }
            set { this.mMatchFound = value; }
        }

        //USED FOR DATAGRIDVIEWCOMBOBOXCOLUMN DISPLAY MEMBER
        public string DisplayString
        {
            get
            {
                string s = String.Empty;

                if (this.mNumber != null)
                    s += "#" + this.mNumber;

                if (this.mFullName != null)
                    s += String.IsNullOrWhiteSpace(s) ? this.mFullName : " / " + this.mFullName;

                return s;
            }
        }

        //USED FOR DATAGRIDVIEWCOMBOBOXCOLUMN VALUE MEMBER
        public RealDriver Self
        {
            get { return this; }
        }

        public override string ToString()
        {
            if (this.mNumber != null)
                return "#" + this.mNumber + " / " + this.mFullName;
            else
                return this.mFullName;
        }


        #region IComparable<RealDriver> Members

        public int CompareTo(RealDriver other)
        {
            int number;
            int numberOther;

            string compareStrNumber = this.Number != null ? this.Number : String.Empty;
            string compareStrNumberOther = other.Number != null ? other.Number : String.Empty;

            string compareStrName = this.FullName != null ? this.FullName : String.Empty;
            string compareStrNameOther = other.FullName != null ? other.FullName : String.Empty;

            if (!String.IsNullOrWhiteSpace(compareStrName) && !String.IsNullOrWhiteSpace(compareStrNameOther))
            {
                return (compareStrName + compareStrNumber).CompareTo((compareStrNameOther + compareStrNumberOther));
            }
            else if (!String.IsNullOrWhiteSpace(compareStrNumber) && !String.IsNullOrWhiteSpace(compareStrNumberOther) && Int32.TryParse(compareStrNumber, out number) && Int32.TryParse(compareStrNumberOther, out numberOther))
            {
                return number.CompareTo(numberOther);
            }
            else
                return compareStrNumber.CompareTo(compareStrNumberOther);

        }

        #endregion
    }
}
