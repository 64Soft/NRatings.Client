namespace NRatings.Client.ApiClient.DTO
{
    public class RaceState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDNFCrash { get; set; }
        public bool IsDNFMechanical { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
