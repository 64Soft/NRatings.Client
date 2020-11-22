using System.Collections.Generic;

namespace NRatings.Client.ApiClient.DTO
{
    public class RacesDetails
    {
        public IList<TrackType> TrackTypes { get; set; } 
        public IList<Track> Tracks { get; set; }     
        public IList<Race> Races { get; set; }
        public IList<RaceState> RaceStates { get; set; } 
        public IList<Driver> Drivers { get; set; }
        public IList<Car> Cars { get; set; } 
        public IList<RaceResult> RaceResults { get; set; }
        public IList<RacePitStopData> RacePitStopDataList { get; set; }
        public IList<RaceLoopData> RaceLoopDataList { get; set; } 
    }
}
