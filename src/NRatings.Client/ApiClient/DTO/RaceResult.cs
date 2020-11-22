namespace NRatings.Client.ApiClient.DTO
{
    public class RaceResult
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int? CarId { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public int? Laps { get; set; }
        public int? LapsLed { get; set; }
        public int? RaceStateId { get; set; }
        public int FinishPosition { get; set; }
        public int? StartPosition { get; set; }
    }
}
