using System.Collections.Generic;

namespace NRatings.Client.Auxiliary
{
    public static class ExtensionMethods
    {
        public static string CapitilizeFirstChar(this string s)
        {
            if (s != null)
            {
                if (!s.Equals(string.Empty))
                {
                    string returnString = s.Clone().ToString();

                    string firstChar = s[0].ToString();
                    string CapitilizedFirstChar = firstChar.ToUpper();

                    returnString = returnString.Remove(0, 1);

                    returnString = returnString.Insert(0, CapitilizedFirstChar);

                    return returnString;
                }
                else
                    return string.Empty;
            }
            else
                return null;
        }

        public static int ToInt(this bool b)
        {
            if (b == true)
                return 1;
            else
                return 0;
        }

        public static int? NullableSum(this IEnumerable<int?> list)
        {
            int? result = new int?();

            foreach (int? item in list)
            {
                if (item.HasValue)
                {
                    if (result.HasValue == false)
                        result = 0;

                    result += item.Value;
                }
            }

            return result;

        }

        public static double? NullableSum(this IEnumerable<double?> list)
        {
            double? result = new double?();

            foreach (double? item in list)
            {
                if (item.HasValue)
                {
                    if (result.HasValue == false)
                        result = 0.0;

                    result += item.Value;
                }
            }

            return result;

        }

    }
}
