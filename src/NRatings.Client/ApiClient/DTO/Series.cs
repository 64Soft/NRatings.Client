using System.Collections.Generic;

namespace NRatings.Client.ApiClient.DTO
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Season> Seasons { get; set; }

        public Series()
        {
            this.Seasons = new List<Season>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
