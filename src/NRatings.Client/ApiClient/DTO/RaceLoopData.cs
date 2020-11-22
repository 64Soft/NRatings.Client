namespace NRatings.Client.ApiClient.DTO
{
    public class RaceLoopData
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int? AveragePosition { get; set; }
        public int? FastestLaps { get; set; }
        public int? GreenFlagPassed { get; set; }
        public int? GreenFlagPasses { get; set; }
        public int? HighestPosition { get; set; }
        public int? LowestPosition { get; set; }
        public int? MidRacePosition { get; set; }
        public int? QualityPasses { get; set; }
        public int? Top15Laps { get; set; }
        public double? Rating { get; set; }
    }
}
