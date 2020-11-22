using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using NRatings.Client.Auxiliary.Exceptions;

namespace NRatings.Client.Auxiliary
{
    //todo: logging

    public static class Helper
    {
        
        private static Random mRand = new Random(DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond);
        
        public static void ShowError(string text, string title)
        {
            //Logger.LogError(text);
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(Exception ex)
        {
            //Logger.LogError(ex);
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(DataProcessingException dpEx)
        {
            //Logger.LogError(dpEx);

            //Logger.LogDebug("Data at time of error:");

            foreach(string key in dpEx.Data.Keys)
            {
                //Logger.LogDebug(key + ": " + dpEx.Data[key]);
            }

            MessageBox.Show(dpEx.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string AssemblyGuidString(System.Reflection.Assembly assembly)
        {
            object[] objects =
            assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            if (objects.Length > 0)
            {
                return ((System.Runtime.InteropServices.GuidAttribute)objects[0]).Value;
            }
            else
            {
                return String.Empty;
            }
        }

        public static T Clone<T>(T OriginalObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, OriginalObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

        public static int GetRandomNumber(int min, int max)
        {
            max++; //MAX is exclusive in below function, so add 1 to make it inclusive
            return mRand.Next(min,max);
        }

        public static string GetRandomString(int length)
        {

            //value of A in ascii codes
            int minValue = 65;
            //value of Z in ascii codes
            int maxValue = 90;
            //the range that we are allowed to go above the min value
            int randomRange = maxValue - minValue;

            double rndValue;

            System.Text.StringBuilder randomText = new System.Text.StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                rndValue = mRand.NextDouble();

                randomText.Append((char)(minValue + rndValue * randomRange));
            }

            return randomText.ToString().ToLower();

           
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }



    }
}
