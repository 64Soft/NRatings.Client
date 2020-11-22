namespace NRatings.Client.ApiClient.DTO
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return this.Name;
        }
    }
}
