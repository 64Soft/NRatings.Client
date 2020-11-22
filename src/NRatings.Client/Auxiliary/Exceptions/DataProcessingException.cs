using System;
using System.Collections.Generic;
using NRatings.Client.Domain;
using Race = NRatings.Client.Domain.Race;

namespace NRatings.Client.Auxiliary.Exceptions
{
    public class DataProcessingException : Exception
    {
        public DataProcessingException(string message, List<Race> selectedRaces, RatingsFormula selectedFormula) 
            : base(message)
        {
            string strSelectedRaces = "/";
            if (selectedRaces != null && selectedRaces.Count > 0)
            {
                strSelectedRaces = "";
                foreach(Race r in selectedRaces)
                {
                    strSelectedRaces += r.Id + ", ";
                }

                strSelectedRaces.TrimEnd(new char[] { ',', ' ' });
            }

            string strSelectedFormula = "/";
            if (selectedFormula != null && !selectedFormula.IsProtected)
            {
                strSelectedFormula = selectedFormula.ToXMLString();
            }

            this.Data.Add("SelectedRaces", strSelectedRaces);
            this.Data.Add("SelectedFormula", strSelectedFormula);
        }
    }
}
