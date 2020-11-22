namespace NRatings.Client.Domain
{
    public class RaceResult
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public Car Car { get; set; }
        public string CarNumber { get; set; }
        public int? Laps { get; set; }
        public int? LapsLed { get; set; }
        public RaceState RaceState { get; set; }
        public int FinishPosition { get; set; }
        public int? StartPosition { get; set; }
    }
}
