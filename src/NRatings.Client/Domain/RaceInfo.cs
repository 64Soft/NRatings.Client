using System.Collections.Generic;

namespace NRatings.Client.Domain
{
    public class RaceInfo
    {
        public Race Race { get; set; }
        public int? NumberOfStarters { get; set; }
        public int? WinnerLaps { get; set; }
    }

    public class RaceInfoComparer : IEqualityComparer<RaceInfo>
    {

        #region IEqualityComparer<RaceInfo> Members

        public bool Equals(RaceInfo x, RaceInfo y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else
            {
                return x.Race == y.Race &&
                        x.WinnerLaps == y.WinnerLaps;
            }
        }

        public int GetHashCode(RaceInfo obj)
        {
            int raceId = 0;
            int winnerLaps = 0;

            if (obj.Race != null)
                raceId = obj.Race.Id;

            if (obj.WinnerLaps.HasValue)
                winnerLaps = obj.WinnerLaps.Value;

            return (raceId.ToString() + winnerLaps.ToString()).GetHashCode();
        }

        #endregion
    }
}
