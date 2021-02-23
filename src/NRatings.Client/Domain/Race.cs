using System;
using System.Collections.Generic;

namespace NRatings.Client.Domain
{
    public class Race : IComparable<Race>
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public string RaceName { get; set; }
        public Track Track { get; set; }
        public DateTime RaceDate { get; set; }
        public double? TrackLengthMiles { get; set; }
        public string Surface { get; set; }
        public double? RaceLengthMiles { get; set; }
        public int? Cautions { get; set; }
        public int? CautionLaps { get; set; }
        public int? LeadChanges { get; set; }

        public string TrackTypeId
        {
            get
            {
                if (this.Surface == "R")
                    return "RC";

                if (this.TrackLengthMiles.HasValue)
                {
                    if (TrackLengthMiles < 1.0)
                        return "ST";
                    if (TrackLengthMiles < 2.0)
                        return "SW";
                    if (TrackLengthMiles >= 2.0)
                        return "SS";
                }

                return null;
            }
        }

        public string NR2003TrackTypeId
        {
            get
            {
                if (this.Surface == "R")
                    return "RC";

                if (this.TrackLengthMiles.HasValue)
                {
                    if (TrackLengthMiles < 1.0)
                        return "ST";
                    else if (this.Track.Name.Contains("Daytona") || this.Track.Name.Contains("Talladega"))
                        return "SS";
                    if (TrackLengthMiles >= 2.0)
                        return "SW";
                }

                return null;
            }
        }

        public IList<RaceResult> RaceResults { get; set; }
        public IList<PitStopData> PitStopDatas { get; set; }
        public IList<LoopData> LoopDatas { get; set; }

        public int CompareTo(Race other)
        {
            int result = RaceDate.CompareTo(other.RaceDate);
            if (result == 0)
            {
                result = Id.CompareTo(other.Id);
            }

            return result;
        }
    }
}
