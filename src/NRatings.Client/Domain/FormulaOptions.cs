using System;
using NRatings.Client.Auxiliary;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class FormulaOptions : ICloneable
    {
        private FormulaOptions defaultOptions;

        
        public bool UseNr2003TrackTypes { get; set; }
        public CarMappingMethod MappingMethod { get; set; }

        public void InitDefaults()
        {
            this.defaultOptions = (FormulaOptions)this.Clone();      
        }

        public void SetToDefaults()
        {
            FormulaOptions defaults = (FormulaOptions)this.defaultOptions.Clone();

            this.UseNr2003TrackTypes = defaults.UseNr2003TrackTypes;
            this.MappingMethod = defaults.MappingMethod;
        }

        public override string ToString()
        {
            return "UseNR2003TrackTypes: " + this.UseNr2003TrackTypes + "\n" +
                   "MapWithDriverNameOnly: " + this.MappingMethod.ToString();
        }

        public object Clone()
        {
            FormulaOptions clone = Helper.Clone<FormulaOptions>(this);
            return clone;
        }
    }
}
