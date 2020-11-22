using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using NRatings.Client.Domain.Collections;

namespace NRatings.Client.Domain
{
    [Serializable]
    public class RatingsFormula
    {
        #region MEMBERS

        private string mName = "";
        private string mAuthor = "";
        private string mVersion = "";
        private string mDescription = "";
        private string mFileName;

        private bool mIsProtected = false;

        private FormulaOptions mOptions = new FormulaOptions();


        private string mDriverAggressionMin = "0";
        private string mDriverAggressionMax = "0";
        private string mDriverConsistencyMin = "0";
        private string mDriverConsistencyMax = "0";
        private string mDriverFinishingMin = "0";
        private string mDriverFinishingMax = "0";
        private string mDriverQualifyingMin = "0";
        private string mDriverQualifyingMax = "0";
        private string mDriverRoadCourseMin = "0";
        private string mDriverRoadCourseMax = "0";
        private string mDriverShortTrackMin = "0";
        private string mDriverShortTrackMax = "0";
        private string mDriverSpeedwayMin = "0";
        private string mDriverSpeedwayMax = "0";
        private string mDriverSuperSpeedwayMin = "0";
        private string mDriverSuperSpeedwayMax = "0";

        private string mVehicleAeroMin = "0";
        private string mVehicleAeroMax = "0";
        private string mVehicleChassisMin = "0";
        private string mVehicleChassisMax = "0";
        private string mVehicleEngineMin = "0";
        private string mVehicleEngineMax = "0";
        private string mVehicleReliabilityMin = "0";
        private string mVehicleReliabilityMax = "0";

        private string mPitcrewConsistencyMin = "0";
        private string mPitcrewConsistencyMax = "0";
        private string mPitcrewSpeedMin = "0";
        private string mPitcrewSpeedMax = "0";
        private string mPitcrewStrategyMin = "0";
        private string mPitcrewStrategyMax = "0";
        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return this.mName; }
            set { this.mName = value; }
        }

        public string Author
        {
            get { return this.mAuthor; }
            set { this.mAuthor = value; }
        }

        public string Version
        {
            get { return this.mVersion; }
            set { this.mVersion = value; }
        }

        public string Description
        {
            get { return this.mDescription; }
            set { this.mDescription = value; }
        }

        [XmlIgnore]
        public string FullDescription
        {
            get
            {
                string s = "";

                if (this.Author != null && this.Author != "")
                {
                    s = "Author: " + this.Author + Environment.NewLine + Environment.NewLine;
                }

                s += this.Description;

                return s;
            }
        }


        [XmlIgnore]
        public string FileName
        {
            get { return this.mFileName; }
            set { this.mFileName = value; }
        }

        public bool IsProtected
        {
            get { return this.mIsProtected;  }
        }


        public FormulaOptions Options
        {
            get { return this.mOptions; }
            set 
            { 
                this.mOptions = value;
                this.mOptions.InitDefaults();
            }
        }


        public string DriverAggressionMin
        {
            get { return this.mDriverAggressionMin; }
            set { this.mDriverAggressionMin = value; }
        }

        public string DriverAggressionMax
        {
            get { return this.mDriverAggressionMax; }
            set { this.mDriverAggressionMax = value; }
        }

        public string DriverConsistencyMin
        {
            get { return this.mDriverConsistencyMin; }
            set { this.mDriverConsistencyMin = value; }
        }

        public string DriverConsistencyMax
        {
            get { return this.mDriverConsistencyMax; }
            set { this.mDriverConsistencyMax = value; }
        }

        public string DriverFinishingMin
        {
            get { return this.mDriverFinishingMin; }
            set { this.mDriverFinishingMin = value; }
        }

        public string DriverFinishingMax
        {
            get { return this.mDriverFinishingMax; }
            set { this.mDriverFinishingMax = value; }
        }

        public string DriverQualifyingMin
        {
            get { return this.mDriverQualifyingMin; }
            set { this.mDriverQualifyingMin = value; }
        }

        public string DriverQualifyingMax
        {
            get { return this.mDriverQualifyingMax; }
            set { this.mDriverQualifyingMax = value; }
        }

        public string DriverRoadCourseMin
        {
            get { return this.mDriverRoadCourseMin; }
            set { this.mDriverRoadCourseMin = value; }
        }

        public string DriverRoadCourseMax
        {
            get { return this.mDriverRoadCourseMax; }
            set { this.mDriverRoadCourseMax = value; }
        }

        public string DriverShortTrackMin
        {
            get { return this.mDriverShortTrackMin; }
            set { this.mDriverShortTrackMin = value; }
        }

        public string DriverShortTrackMax
        {
            get { return this.mDriverShortTrackMax; }
            set { this.mDriverShortTrackMax = value; }
        }

        public string DriverSpeedwayMin
        {
            get { return this.mDriverSpeedwayMin; }
            set { this.mDriverSpeedwayMin = value; }
        }

        public string DriverSpeedwayMax
        {
            get { return this.mDriverSpeedwayMax; }
            set { this.mDriverSpeedwayMax = value; }
        }

        public string DriverSuperSpeedwayMin
        {
            get { return this.mDriverSuperSpeedwayMin; }
            set { this.mDriverSuperSpeedwayMin = value; }
        }

        public string DriverSuperSpeedwayMax
        {
            get { return this.mDriverSuperSpeedwayMax; }
            set { this.mDriverSuperSpeedwayMax = value; }
        }


        public string VehicleAeroMin
        {
            get { return this.mVehicleAeroMin; }
            set { this.mVehicleAeroMin = value; }
        }

        public string VehicleAeroMax
        {
            get { return this.mVehicleAeroMax; }
            set { this.mVehicleAeroMax = value; }
        }

        public string VehicleChassisMin
        {
            get { return this.mVehicleChassisMin; }
            set { this.mVehicleChassisMin = value; }
        }

        public string VehicleChassisMax
        {
            get { return this.mVehicleChassisMax; }
            set { this.mVehicleChassisMax = value; }
        }

        public string VehicleEngineMin
        {
            get { return this.mVehicleEngineMin; }
            set { this.mVehicleEngineMin = value; }
        }

        public string VehicleEngineMax
        {
            get { return this.mVehicleEngineMax; }
            set { this.mVehicleEngineMax = value; }
        }

        public string VehicleReliabilityMin
        {
            get { return this.mVehicleReliabilityMin; }
            set { this.mVehicleReliabilityMin = value; }
        }

        public string VehicleReliabilityMax
        {
            get { return this.mVehicleReliabilityMax; }
            set { this.mVehicleReliabilityMax = value; }
        }

        public string PitcrewConsistencyMin
        {
            get { return this.mPitcrewConsistencyMin; }
            set { this.mPitcrewConsistencyMin = value; }
        }

        public string PitcrewConsistencyMax
        {
            get { return this.mPitcrewConsistencyMax; }
            set { this.mPitcrewConsistencyMax = value; }
        }

        public string PitcrewSpeedMin
        {
            get { return this.mPitcrewSpeedMin; }
            set { this.mPitcrewSpeedMin = value; }
        }

        public string PitcrewSpeedMax
        {
            get { return this.mPitcrewSpeedMax; }
            set { this.mPitcrewSpeedMax = value; }
        }

        public string PitcrewStrategyMin
        {
            get { return this.mPitcrewStrategyMin; }
            set { this.mPitcrewStrategyMin = value; }
        }

        public string PitcrewStrategyMax
        {
            get { return this.mPitcrewStrategyMax; }
            set { this.mPitcrewStrategyMax = value; }
        }


        #endregion


        public override string ToString()
        {
            string type = "";
            string version = "";

            if (this.mVersion != null)
                version = this.mVersion;

            return this.mName + " " + type + " " + version;
        }

        public string ToXMLString()
        {
            try
            {
                string res = null;

                if (!this.mIsProtected)
                {
                    StringWriter sw = new StringWriter();
                    XmlSerializer xs = new XmlSerializer(typeof(RatingsFormula));
                    xs.Serialize(sw, this);

                    res = sw.ToString();

                    return res;
                }

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static RatingsFormula ReadFromFile(string filepath)
        {
            try
            {
                RatingsFormula rf = new RatingsFormula();

                if (File.Exists(filepath))
                {
                    FileStream fs = new FileStream(filepath, FileMode.Open);
                    XmlSerializer xs = new XmlSerializer(typeof(RatingsFormula));
                    rf = (RatingsFormula)xs.Deserialize(fs);
                    fs.Close();
                }
                else
                    rf = null;

                return rf;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on Reading Ratings File " + filepath + ": " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
