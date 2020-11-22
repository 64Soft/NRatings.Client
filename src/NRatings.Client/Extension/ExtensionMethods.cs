using System;

namespace NRatings.Client.Extension
{
    public static class ExtensionMethods
    {
        public static double Round(this double d, int precision)
        {
            return Math.Round(d, precision);
        }

        public static double? Round(this double? d, int precision)
        {
            if (d.HasValue)
                return Math.Round(d.Value, precision);
            else
                return d;
        }
    }
}
