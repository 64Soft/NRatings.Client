using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using NRatings.Client.EventHandling;
using NRatings.Client.Validation;

namespace NRatings.Client.Domain
{
    public class NR2003Car : IComparable<NR2003Car>, INotifyPropertyChanged
    {

        private string mFileName;
        private string mPath;
        private string mNumber;
        private string mDriverFirstName;
        private string mDriverLastName;
        private Ratings mRatings;
        private RealDriver mMappedToRealDriver;
        private bool mSelected = false;

        private string mDriverFirstName_Original;
        private string mDriverLastName_Original;
        private Ratings mRatings_Original;

        private bool mIsDirty = false;

        public event EventHandler<EventArgs<bool>> IsDirtyChanged;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public enum RevertType
        {
            NameOnly = 1,
            RatingsOnly = 2,
            Completely = 3
        };

        public string FileName
        {
            get { return this.mFileName; }
            set { this.mFileName = value; }
        }

        public string Path
        {
            get { return this.mPath; }
            set { this.mPath = value; }
        }

        public string Number
        {
            get { return this.mNumber; }
            set { this.mNumber = value; }
        }

        public string DriverFirstName
        {
            get { return this.mDriverFirstName; }
            set
            {
                value = value != null ? value : string.Empty; //AVOID NULL VALUES

                if (value != this.mDriverFirstName)
                {
                    this.mDriverFirstName = value;
                    this.OnPropertyChanged("DriverFirstName");
                }
                
            }
        }

        public string DriverLastName
        {
            get { return this.mDriverLastName; }
            set
            {
                value = value != null ? value : string.Empty; //AVOID NULL VALUES

                if (value != this.mDriverLastName)
                {
                    this.mDriverLastName = value;
                    this.OnPropertyChanged("DriverLastName");
                }
            }
        }

        public Ratings Ratings
        {
            get { return this.mRatings; }
            set 
            {
                if (value != this.mRatings)
                {
                    this.mRatings = value;

                    this.mRatings.Changed += new EventHandler(RatingsValuesChanged); //WHEN A NEW RATINGS OBJECT IS ASSIGNED (TYPICALLY AFTER A CLONE OPERATION), WE NEED TO REATTACH A CHANGE EVENTHANDLER

                    this.OnPropertyChanged("Ratings");
                }
            }
        }

        public RealDriver MappedToRealDriver
        {
            get { return this.mMappedToRealDriver; }
            set 
            {
                if (value != this.mMappedToRealDriver)
                {
                    this.mMappedToRealDriver = value;

                    if (this.mMappedToRealDriver != null)
                    {
                        if (this.mMappedToRealDriver.Ratings != null)
                            this.Ratings = (Ratings)this.mMappedToRealDriver.Ratings.Clone();
                    }
                    
                    this.OnPropertyChanged("MappedToRealDriver");
                }
            }
        }

        public bool Selected
        {
            get { return this.mSelected; }
            set { this.mSelected = value; }
        }

        public bool IsDirty
        {
            get { return this.mIsDirty; }
            set 
            {
                if (value != this.mIsDirty)
                {
                    this.mIsDirty = value;
                    this.OnIsDirtyChanged(value);
                }
            }
        }

        public NR2003Car(string path, string fileName)
        {
            this.mPath = path;
            this.mFileName = fileName;

            //this.ReadCarInfo();
        }

        private void SetOriginalToCurrent()
        {
            try
            {
                this.mDriverFirstName_Original = this.mDriverFirstName;
                this.mDriverLastName_Original = this.mDriverLastName;
                this.mRatings_Original = (Ratings)this.mRatings.Clone();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not set original values: " + ex.ToString());
            }
        }

        public void RevertToOriginal(RevertType revertType)
        {
            try
            {
                switch (revertType)
                {
                    case RevertType.NameOnly:
                        this.DriverFirstName = this.mDriverFirstName_Original;
                        this.DriverLastName = this.mDriverLastName_Original;
                        break;

                    case RevertType.RatingsOnly:
                        this.MappedToRealDriver = null;
                        this.Ratings = (Ratings)this.mRatings_Original.Clone();
                        break;

                    case RevertType.Completely:
                        this.DriverFirstName = this.mDriverFirstName_Original;
                        this.DriverLastName = this.mDriverLastName_Original;
                        this.MappedToRealDriver = null;
                        this.Ratings = (Ratings)this.mRatings_Original.Clone();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public ValidatedResult<bool> Validate()
        {
            ValidatedResult<bool> result = new ValidatedResult<bool>();

            result.ReturnObject = true;

            if (this.mDriverFirstName == null || this.mDriverLastName == null || this.mRatings == null)
            {
                result.Messages.Add(new Message(Message.MessageType.Error, "FirstName, LastName and Ratings cannot be NULL"));
                result.ReturnObject = false;
            }

            else if (this.mDriverFirstName.Length < 1 || this.mDriverLastName.Length < 1)
            {
                result.Messages.Add(new Message(Message.MessageType.Error, "FirstName and LastName must have at least one character"));
                result.ReturnObject = false;
            }


            return result;
        }

        
        public void ReadCarInfo()
        {
            if (this.mPath != null && this.mFileName != null)
            {
                try
                {
                    FileStream fs = new FileStream(this.mPath + @"\" + this.mFileName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] buffer = br.ReadBytes(1500);
                    fs.Close();


                    Encoding encoding = Encoding.Default;

                    string str = encoding.GetString(buffer);

                    //Console.WriteLine("*" + str + "*");

                    this.mNumber = this.GetCarParameter(str, "car_number", false);
                    this.mDriverFirstName = this.GetCarParameter(str, "first_name", false);
                    this.mDriverLastName = this.GetCarParameter(str, "last_name", false);

                   
                    //GET RATINGS
                    int deviationPartStart = str.IndexOf(@"[AIParamDeviation]");
                    int meanPartStart = str.IndexOf(@"[AIParamMean]");
                    int careerPartStart = str.IndexOf(@"[CareerStats]");

                    string deviationPart = str.Substring(deviationPartStart, meanPartStart - deviationPartStart - 1);
                    string meanPart = str.Substring(meanPartStart, careerPartStart - meanPartStart - 1);

                    this.mRatings = new Ratings();

                   
                    this.mRatings.GetRating("dr_aggr").Dev =  Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverAggression", true));
                    this.mRatings.GetRating("dr_aggr").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverAggression", true));

                    this.mRatings.GetRating("dr_cons").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverConsistency", true));
                    this.mRatings.GetRating("dr_cons").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverConsistency", true));

                    this.mRatings.GetRating("dr_fin").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverFinishing", true));
                    this.mRatings.GetRating("dr_fin").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverFinishing", true));

                    this.mRatings.GetRating("dr_qual").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverQualifying", true));
                    this.mRatings.GetRating("dr_qual").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverQualifying", true));

                    this.mRatings.GetRating("dr_rc").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverRoadCourse", true));
                    this.mRatings.GetRating("dr_rc").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverRoadCourse", true));

                    this.mRatings.GetRating("dr_st").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverShortTrack", true));
                    this.mRatings.GetRating("dr_st").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverShortTrack", true));

                    this.mRatings.GetRating("dr_sw").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverSpeedway", true));
                    this.mRatings.GetRating("dr_sw").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverSpeedway", true));

                    this.mRatings.GetRating("dr_ss").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamDriverSuperspeedway", true));
                    this.mRatings.GetRating("dr_ss").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamDriverSuperspeedway", true));

                    this.mRatings.GetRating("veh_aero").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamVehicleAero", true));
                    this.mRatings.GetRating("veh_aero").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamVehicleAero", true));

                    this.mRatings.GetRating("veh_chas").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamVehicleChassis", true));
                    this.mRatings.GetRating("veh_chas").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamVehicleChassis", true));

                    this.mRatings.GetRating("veh_eng").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamVehicleEngine", true));
                    this.mRatings.GetRating("veh_eng").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamVehicleEngine", true));

                    this.mRatings.GetRating("veh_rel").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamVehicleReliability", true));
                    this.mRatings.GetRating("veh_rel").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamVehicleReliability", true));

                    this.mRatings.GetRating("pc_cons").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamPitcrewConsistency", true));
                    this.mRatings.GetRating("pc_cons").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamPitcrewConsistency", true));

                    this.mRatings.GetRating("pc_spe").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamPitcrewSpeed", true));
                    this.mRatings.GetRating("pc_spe").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamPitcrewSpeed", true));

                    this.mRatings.GetRating("pc_strat").Dev = Convert.ToDouble(this.GetCarParameter(deviationPart, "aiParamPitcrewStrategy", true));
                    this.mRatings.GetRating("pc_strat").Mean = Convert.ToDouble(this.GetCarParameter(meanPart, "aiParamPitcrewStrategy", true));

                    this.mRatings.Changed += new EventHandler(RatingsValuesChanged);

                    this.SetOriginalToCurrent();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }

            }

        }

        public bool testSave()
        {
            FileStream fs = new FileStream(this.mPath + @"\" + this.mFileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            byte[] buffer = br.ReadBytes((int)fs.Length);

            fs.Close();

            fs = new FileStream(this.mPath + @"\test.cup.car", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buffer);
            fs.Close();

            return true;
        }

        
        public bool SaveCarToFile()
        {
            if (this.mPath != null && this.mFileName != null)
            {
                try
                {
                    Console.WriteLine("Saving car " + this.mNumber);

                    Encoding encoding = Encoding.Default;

                    FileStream fs = new FileStream(this.mPath + @"\" + this.mFileName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    
                    //READ HEADER VARIABLES
                    char[] CarFileChars = br.ReadChars(4);
                    int CarFileInt1 = br.ReadInt32();
                    int CarFileInt2 = br.ReadInt32(); //FILE SIZE IN BYTES - 12
                    char[] CarTypeChars = br.ReadChars(4);
                    int CarTypeInt1 = br.ReadInt32();
                    int CarTypeInt2 = br.ReadInt32();
                    int CarTypeInt3 = br.ReadInt32();
                    char[] CarIniChars = br.ReadChars(4);
                    int CarIniInt1 = br.ReadInt32();
                    int CarIniInt2 = br.ReadInt32(); //INI LENGTH IN BYTES

                    int FileSizeMinus12 = CarFileInt2;
                    int IniSize = CarIniInt2;
                    
                    //READ PARAMETERS, CONVERT IT TO STRING FOR PROCESSING
                    byte[] binParameters = br.ReadBytes(IniSize);
                    string strParameters = encoding.GetString(binParameters);
        
                    //SKIP THE DUMMY BYTES BETWEEN END OF PARAMATERS AND BEGIN OF TEXTURES (XETC MUST BE AT BEGINNING OF A GROUP OF 4 BYTES)     
                    byte[] tempBuf = new byte[1];
                    while (br.BaseStream.Position < br.BaseStream.Length && !encoding.GetString(tempBuf).Equals("X"))
                    {
                        tempBuf = br.ReadBytes(1);
                    }

                    br.BaseStream.Seek(-1, SeekOrigin.Current);

                    //READ TEXTURE DATA
                    byte[] textureData = br.ReadBytes((int)(fs.Length));

                    string texStr = encoding.GetString(textureData);


                    //CLOSE THE STREAM
                    fs.Close();

                   
                    string ParamName = "";
                    int ParamStart = -1;
                    int ParamEnd = -1;
                    string line = "";

                    //SET NAME
                    int driverPartStart = strParameters.IndexOf(@"[Driver]");
                    int driverPartEnd = strParameters.Length;
                    string driverPart = strParameters.Substring(driverPartStart, driverPartEnd - driverPartStart - 1);
                    string oldDriverPart = driverPart;

                   
                    ParamName = "first_name=";
                    ParamStart = driverPart.IndexOf(ParamName);
                    ParamEnd = driverPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = driverPart.Substring(ParamStart, ParamEnd - ParamStart);
                    driverPart = driverPart.Replace(line, this.SetCarParameter(line, this.mDriverFirstName, false));

                    ParamName = "last_name=";
                    ParamStart = driverPart.IndexOf(ParamName);
                    ParamEnd = driverPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = driverPart.Substring(ParamStart, ParamEnd - ParamStart);
                    driverPart = driverPart.Replace(line, this.SetCarParameter(line, this.mDriverLastName, false));



                    ParamName = "";
                    ParamStart = -1;
                    ParamEnd = -1;
                    line = "";

                    //SET RATINGS
                    int deviationPartStart = strParameters.IndexOf(@"[AIParamDeviation]");
                    int meanPartStart = strParameters.IndexOf(@"[AIParamMean]");
                    int careerPartStart = strParameters.IndexOf(@"[CareerStats]");
                    

                    string deviationPart = strParameters.Substring(deviationPartStart, meanPartStart - deviationPartStart - 1);
                    string meanPart = strParameters.Substring(meanPartStart, careerPartStart - meanPartStart - 1);

                    string oldDeviationPart = deviationPart;
                    string oldMeanPart = meanPart;

                    ParamName = "aiParamDriverAggression=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_aggr").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_aggr").Mean.ToString(),true));

                    ParamName = "aiParamDriverConsistency=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_cons").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_cons").Mean.ToString(), true));

                    ParamName = "aiParamDriverFinishing=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_fin").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_fin").Mean.ToString(), true));

                    ParamName = "aiParamDriverQualifying=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_qual").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_qual").Mean.ToString(), true));

                    ParamName = "aiParamDriverRoadCourse=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_rc").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_rc").Mean.ToString(), true));

                    ParamName = "aiParamDriverShortTrack=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_st").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_st").Mean.ToString(), true));

                    ParamName = "aiParamDriverSpeedway=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_sw").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_sw").Mean.ToString(), true));

                    ParamName = "aiParamDriverSuperspeedway=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_ss").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("dr_ss").Mean.ToString(), true));

                    ParamName = "aiParamPitcrewConsistency=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_cons").Dev.ToString(), true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_cons").Mean.ToString(), true));

                    ParamName = "aiParamPitcrewSpeed=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_spe").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_spe").Mean.ToString(),true));

                    ParamName = "aiParamPitcrewStrategy=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_strat").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("pc_strat").Mean.ToString(),true));

                    ParamName = "aiParamVehicleAero=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_aero").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_aero").Mean.ToString(),true));

                    ParamName = "aiParamVehicleChassis=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_chas").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_chas").Mean.ToString(),true));

                    ParamName = "aiParamVehicleEngine=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_eng").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_eng").Mean.ToString(),true));

                    ParamName = "aiParamVehicleReliability=";
                    ParamStart = deviationPart.IndexOf(ParamName);
                    ParamEnd = deviationPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = deviationPart.Substring(ParamStart, ParamEnd - ParamStart);
                    deviationPart = deviationPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_rel").Dev.ToString(),true));
                    ParamStart = meanPart.IndexOf(ParamName);
                    ParamEnd = meanPart.IndexOf(System.Environment.NewLine, ParamStart);
                    line = meanPart.Substring(ParamStart, ParamEnd - ParamStart);
                    meanPart = meanPart.Replace(line, this.SetCarParameter(line, this.mRatings.GetRating("veh_rel").Mean.ToString(),true));

                    
                    strParameters = strParameters.Replace(oldDeviationPart, deviationPart);
                    strParameters = strParameters.Replace(oldMeanPart, meanPart);
                    strParameters = strParameters.Replace(oldDriverPart, driverPart);

                    //END TRANSFORMATION

                    //CONVERT STRING PARAMETERS BACK TO BYTE ARRAY
                    binParameters = encoding.GetBytes(strParameters);


                    //COMPUTE VARIABLES FOR HEADER
                    IniSize = binParameters.Length;

                    //Texture part (XETC) must start at new group of 4 bytes. Therefore, insert x number of bytes until dividable by 4.
                    int bytesToInsertAfterIni = 4 - (IniSize % 4);
                    if (bytesToInsertAfterIni == 4)
                        bytesToInsertAfterIni = 0;

                    FileSizeMinus12 = 40 + IniSize + bytesToInsertAfterIni + textureData.Length - 12; // 40 = total bytes before parameters start
                    
                    //OPEN NEW FILESTREAM FOR WRITING, TRUNCATING THE EXISTING FILE
                    fs = new FileStream(this.mPath + @"\" + this.mFileName, FileMode.Create);
                    //fs = new FileStream(this.mPath + @"\test.cup.car", FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    
                    //WRITE THE APPROPRIATE DATA

                    bw.Write(CarFileChars);
                    bw.Write(CarFileInt1);
                    bw.Write(FileSizeMinus12);
                    bw.Write(CarTypeChars);
                    bw.Write(CarTypeInt1);
                    bw.Write(CarTypeInt2);
                    bw.Write(CarTypeInt3);
                    bw.Write(CarIniChars);
                    bw.Write(CarIniInt1);
                    bw.Write(IniSize);
                    bw.Write(binParameters);
                    for (int i = 0; i < bytesToInsertAfterIni; i++)
                    {
                        bw.Write((byte)32);
                    }
                    bw.Write(textureData);

                    bw.Flush();
                    
                    //CLOSE THE STREAM
                    fs.Close();

                    this.SetOriginalToCurrent();

                    return true;

                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }


            }
            return false;
        }

        public int CompareTo(NR2003Car c)
        {
            return Convert.ToInt32(this.mNumber).CompareTo(Convert.ToInt32(c.mNumber));
        }

        private string GetCarParameter(string source, string parameterName, bool isRating)
        {
            char[] splitter = { '=' };

            int startIndex = source.IndexOf(parameterName + @"=");
            string line = source.Substring(startIndex, source.IndexOf(System.Environment.NewLine, startIndex) - startIndex);

            if (isRating == true)
                return line.Split(splitter)[1].Trim().Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            else
                return line.Split(splitter)[1].Trim();
        }

        private string SetCarParameter(string parameterLine, string value, bool isRating)
        {
            char[] splitter = { '=' };

            string parameter = parameterLine.Split(splitter)[0];
            string v = value;

            if (isRating == true)
            {
                if (v.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) == -1)
                    v = v + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

                v = v.Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
                while (v.Length < 8)
                    v = v + "0";
            }
            
            return parameter + "=" + v;

        }

        private void RatingsValuesChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged("RatingsValues");
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            Console.WriteLine(this.ToString() + " " + propertyName + " --> Changed");

            //CHECK IF DIRTY BY CHECKING FIRST NAME, LAST NAME AND RATINGS AGAINST ORIGINALS
            if (this.mDriverFirstName.Equals(this.mDriverFirstName_Original) && this.mDriverLastName.Equals(this.mDriverLastName_Original) && this.mRatings.Equals(this.mRatings_Original))
            {
                this.IsDirty = false;
            }
            else
                this.IsDirty = true;

            //UNMAP FROM REALDRIVER IF THE RATINGS ARE NOT EQUAL
            if (this.mMappedToRealDriver != null)
            {
                if(this.mMappedToRealDriver.Ratings != null && !this.mRatings.Equals(this.mMappedToRealDriver.Ratings))
                    this.MappedToRealDriver = null;
            }


            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnIsDirtyChanged(bool isDirty)
        {
            if (this.IsDirtyChanged != null)
                this.IsDirtyChanged(this, new EventArgs<bool>(isDirty));
        }

        public override string ToString()
        {
            return "#" + this.mNumber + " " + this.mDriverFirstName + " " + this.mDriverLastName + " (" + this.mFileName + ")";
        }

    }
}
