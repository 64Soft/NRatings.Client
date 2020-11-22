namespace NRatings.Client.ApiClient.DTO
{
    public class TrackType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
