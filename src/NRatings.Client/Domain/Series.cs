using System.Collections.Generic;

namespace NRatings.Client.Domain
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Season> Seasons { get; set; } 
         
        public override string ToString()
        {
            return this.Name;
        }
    }
}
