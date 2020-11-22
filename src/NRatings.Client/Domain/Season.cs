namespace NRatings.Client.Domain
{
    public class Season
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
