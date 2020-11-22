namespace NRatings.Client.Domain
{
    public class RaceState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDNFCrash { get; set; }
        public bool IsDNFMechanical { get; set; }

        public bool IsDNF
        {
            get { return this.IsDNFCrash || this.IsDNFMechanical; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
