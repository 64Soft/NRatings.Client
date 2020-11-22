namespace NRatings.Client.ApiClient.DTO
{
    public class RacePitStopData
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int? NrOfStops { get; set; }
        public double? AverageTime { get; set; }
        public double? TotalTime { get; set; }
        public bool InGarage { get; set; }
    }
}
