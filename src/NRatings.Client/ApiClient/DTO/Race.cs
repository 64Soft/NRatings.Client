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
        public double? TrackLengthMiles { get; set; }
        public string Surface { get; set; }
        public double? RaceLengthMiles { get; set; }
        public int? Cautions { get; set; }
        public int? CautionLaps { get; set; }
        public int? LeadChanges { get; set; }
    }
}
