using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NRatings.Client.Domain.Collections
{
    public class RealDriverCollection: List<RealDriver>
    {
        private Regex nonAlphaNum = new Regex(@"[^A-Za-z0-9]");

        public RealDriver FindByName(string firstName, string lastName)
        {
            try
            {
                var q = from RealDriver rd in this
                        where String.Equals(this.nonAlphaNum.Replace(rd.FullName, "").ToLower(), this.nonAlphaNum.Replace(firstName + " " + lastName, "").ToLower())
                        select rd;

                return q.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public RealDriver FindByNumber(string number)
        {
            try
            {
                var q = from RealDriver rd in this
                        where String.Equals(rd.Number, number)
                        select rd;

                return q.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public RealDriver FindByNumberAndName(string number, string firstName, string lastName)
        {
            try
            {
                var q = from RealDriver rd in this
                        where String.Equals(this.nonAlphaNum.Replace(rd.FullName, "").ToLower(), this.nonAlphaNum.Replace(firstName + " " + lastName, "").ToLower())
                        && String.Equals(rd.Number, number)
                        select rd;

                return q.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


    }
}
