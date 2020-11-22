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
        public string TrackTypeId { get; set; }
        public string NR2003TrackTypeId { get; set; }

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
