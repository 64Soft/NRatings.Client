namespace NRatings.Client.Domain
{
    internal class RatingsPerformanceWeight
    {
        public string RatingName { get; set; }
        public string TrackTypeName { get; set; }
        public SessionType Session { get; set; }
        public int PerformanceCoefficient { get; set; }
    }
}
