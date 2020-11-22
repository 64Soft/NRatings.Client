using System;

namespace NRatings.Client.ApiClient.DTO
{
    public class Race
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string RaceName { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public DateTime RaceDate { get; set; }    
        public string TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }
        public string NR2003TrackTypeId { get; set; }
        public string NR2003TrackTypeName { get; set; }
    }
}
