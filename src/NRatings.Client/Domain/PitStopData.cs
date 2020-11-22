namespace NRatings.Client.Domain
{
    public class PitStopData
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public Race Race { get; set; }
        public int? NrOfStops { get; set; }
        public double? AverageTime { get; set; }
        public double? TotalTime { get; set; }
        public bool InGarage { get; set; }
    }
}
