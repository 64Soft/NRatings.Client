namespace NRatings.Client.Domain
{
    public class DriverRaceData
    {
        public Race Race { get; set; }
        public Driver Driver { get; set; }
        public RaceState RaceState { get; set; }
        public Car Car { get; set; }
        public RaceResult RaceResult { get; set; }
        public LoopData LoopData { get; set; }
        public PitStopData PitStopData { get; set; }
        public int? PitStopRank { get; set; }
    }
}
