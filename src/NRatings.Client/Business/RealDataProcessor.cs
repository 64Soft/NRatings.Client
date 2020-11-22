using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NRatings.Client.Auxiliary;
using NRatings.Client.Auxiliary.Exceptions;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;
using NRatings.Client.Extension;

namespace NRatings.Client.Business
{
    public class RealDataProcessor
    {
        
        private RRDataFetcher rdf;
        private static List<TrackType> trackTypes;
        private List<Race> selectedRaces;
        private RatingsFormula selectedFormula;

        private RealDriverCollection realDrivers;
        private bool rosterOnly = false;
        
        private List<Race> fetchedRaceList;
        private List<DriverRaceData> driverRaceDataList; //FETCHED FROM SERVER

        private Dictionary<string, List<RaceInfo>> selectedRacesInfo; //COMPUTED FROM FETCHED DATA. CONTAINS GLOBAL STATS PER RACE VALID FOR ALL DRIVERS
        private Dictionary<string, List<DriverStats>> driverStatsByType; //COMPUTED FROM FETCHED DATA

        private DataProcessingException dataProcessingException;

        public event EventHandler SelectedRacesChanged;
             
        public List<Race> SelectedRaces
        {
            get { return this.selectedRaces; }
        }

        public RatingsFormula SelectedFormula
        {
            get { return this.selectedFormula; }
            set { this.selectedFormula = value; }
        }

        public Dictionary<string, List<RaceInfo>> SelectedRacesInfo
        {
            get { return this.selectedRacesInfo; }
        }

        public Dictionary<string, List<DriverStats>> DriverStatsByType
        {
            get { return this.driverStatsByType; }
        }

        public List<TrackType> TrackTypes
        {
            get { return trackTypes; }
        }

        public RealDriverCollection RealDrivers
        {
            get { return this.realDrivers; }
        }

        public DataProcessingException DataProcessingException
        {
            get { return this.dataProcessingException; }
        }

        public bool CarListOnly
        {
            get { return this.rosterOnly; }
            set { this.rosterOnly = value; }
        }
      
        public RealDataProcessor()
        {
            this.rdf = new RRDataFetcher();
            this.selectedRaces = new List<Race>();
            this.fetchedRaceList = new List<Race>();
            this.selectedRacesInfo = new Dictionary<string, List<RaceInfo>>();
            this.driverStatsByType = new Dictionary<string, List<DriverStats>>();

            if (trackTypes == null)
                trackTypes = Task.Run(() => this.rdf.GetTrackTypesAsync()).Result as List<TrackType>;    
        }

        public IList<Series> GetSeries()
        {
            return Task.Run(() => this.rdf.GetSeriesAsync()).Result;
        }

        public IList<Race> GetRaces(Season season)
        {
            return Task.Run(() => this.rdf.GetRacesAsync(season)).Result;
        }

        public void SelectRace(Race race, bool select)
        {
            if (select == true)
            {
                if (!this.selectedRaces.Contains(race))
                {
                    this.selectedRaces.Add(race);
                    this.OnSelectedRacesChanged();

                }
            }
            else
            {
                this.selectedRaces.Remove(race);
                this.OnSelectedRacesChanged();
            }
        }

        public void OnSelectedRacesChanged()
        {
            if (this.SelectedRacesChanged != null)
                this.SelectedRacesChanged(this, null);
        }

        public void ClearSelectedRaces()
        {
            this.selectedRaces.Clear();
        }

        public void GetDriverRaceData()
        {
            this.dataProcessingException = null;

            try
            {
                List<int> selectedIds = (from r in this.selectedRaces
                                         orderby r.Id
                                         select r.Id).ToList();

                List<int> fetchedIds = (from r in this.fetchedRaceList
                                        orderby r.Id
                                        select r.Id).ToList();

                if (fetchedIds.Count == 0 || !selectedIds.SequenceEqual(fetchedIds))
                {
                    this.fetchedRaceList.Clear();

                    this.driverRaceDataList = Task.Run(() => this.rdf.GetDriverRaceDataAsync(this.selectedRaces)).Result as List<DriverRaceData>;

                    foreach (Race r in this.selectedRaces)
                        this.fetchedRaceList.Add(r);
                }
            }
            catch (Exception ex)
            {
                DataProcessingException dpEx = new DataProcessingException(ex.Message, this.selectedRaces, this.selectedFormula);
                this.dataProcessingException = dpEx;
            }
        }

        public void ComputeDriverStatsForEachTrackType()
        {
            try
            {
                this.selectedRacesInfo.Clear();
                this.driverStatsByType.Clear();

                RatingsFormula formula = this.selectedFormula;

                if (formula != null)
                {

                    List<RaceInfo> racesInfo = (from r in this.selectedRaces
                                                select new RaceInfo
                                                {
                                                    Race = r,
                                                    WinnerLaps = (from drd in driverRaceDataList
                                                                  where drd.Race.Id == r.Id
                                                                  && drd.RaceResult != null
                                                                  && drd.RaceResult.FinishPosition == 1
                                                                  select drd.RaceResult.Laps).FirstOrDefault(),
                                                    NumberOfStarters = (from drd in driverRaceDataList
                                                                        where drd.Race.Id == r.Id
                                                                        && drd.RaceResult != null
                                                                        select drd.RaceResult).Count()
                                                }).ToList();

                    this.selectedRacesInfo.Add("ALL", racesInfo);

                    
                    List<DriverStats> statsAll = this.ComputeDriverStats(this.driverRaceDataList, racesInfo, formula.Options.MappingMethod);

                    this.driverStatsByType.Add("ALL", statsAll);

                    foreach (TrackType tt in trackTypes)
                    {
                        int countSelected;

                        List<DriverRaceData> driverRaceDataForSpecificType;
                        List<RaceInfo> racesInfoForSpecificType;

                        if (formula.Options.UseNr2003TrackTypes == false)
                        {
                            driverRaceDataForSpecificType = (from drd in driverRaceDataList
                                                             where String.Equals(drd.Race.TrackTypeId, tt.Id)
                                                             select drd).ToList();

                            racesInfoForSpecificType = (from ri in racesInfo
                                                        where String.Equals(ri.Race.TrackTypeId, tt.Id)
                                                        select ri).ToList();

                            countSelected = racesInfoForSpecificType.Count;
                        }
                        else
                        {
                            driverRaceDataForSpecificType = (from drd in driverRaceDataList
                                                             where String.Equals(drd.Race.NR2003TrackTypeId, tt.Id)
                                                             select drd).ToList();

                            racesInfoForSpecificType = (from ri in racesInfo
                                                        where String.Equals(ri.Race.NR2003TrackTypeId, tt.Id)
                                                        select ri).ToList();

                            countSelected = racesInfoForSpecificType.Count;
                        }

                        this.selectedRacesInfo.Add(tt.Id, racesInfoForSpecificType);


                        List<DriverStats> stats = this.ComputeDriverStats(driverRaceDataForSpecificType, racesInfoForSpecificType, formula.Options.MappingMethod);

                        var nonFoundDriversForThisTrackType = from s in statsAll
                                                              where stats.Contains(s, new DriverStatsComparerByNumberAndName()) == false
                                                              select s;

                        foreach(DriverStats ds in nonFoundDriversForThisTrackType)
                        {
                            DriverStats nonFoundDriver = new DriverStats();
                            nonFoundDriver.CarNumber = ds.CarNumber;
                            nonFoundDriver.Driver = ds.Driver;

                            stats.Add(nonFoundDriver);
                        }

                        this.driverStatsByType.Add(tt.Id, stats);

                    }
                }
            }
            catch (Exception ex)
            {
                DataProcessingException dpEx = new DataProcessingException(ex.Message, this.selectedRaces, this.selectedFormula);
                this.dataProcessingException = dpEx;
            }
        }

        public void CalculateRatings()
        {

            try
            {

                this.realDrivers = new RealDriverCollection();

                RatingsFormula formula = this.selectedFormula;

                foreach (DriverStats statAll in this.driverStatsByType["ALL"])
                {

                    RealDriver d = new RealDriver();


                    d.Number = statAll.CarNumber;

                    if(statAll.Driver != null)
                        d.FullName = statAll.Driver.Name;

                    if (this.CarListOnly == false)
                    {


                        //GET A DICTIONARY OF STATS (BY TRACKTYPE) FOR THIS DRIVER
                        Dictionary<string, DriverStats> singleDriverStatsByType = this.GetSingleDriverStatsByType(this.driverStatsByType, formula.Options.MappingMethod, statAll.CarNumber, statAll.Driver);

                        Dictionary<string, object> variables = new Dictionary<string, object>();


                        Type DriverStatsType = typeof(DriverStats); //USING REFLECTION TO MAP THE DRIVERSTATS PROPERTIES TO THE VARIABLES

                        //TRACKTYPE SPECIFIC VARIABLES
                        foreach (TrackType tt in trackTypes)
                        {
                            variables.Add("@countSelectedRaces" + tt.Id, this.selectedRacesInfo[tt.Id].Count);

                            foreach (string variable in FormulaVariableList.GetList())
                            {
                                string propertyName = variable.Replace("@", "").CapitilizeFirstChar();

                                PropertyInfo pi = DriverStatsType.GetProperty(propertyName);
                                object val = pi.GetValue(singleDriverStatsByType[tt.Id], null);

                                variables.Add(variable + tt.Id, val);
                            }
                        }

                        //VARIABLES FOR ALL TRACKTYPES
                        variables.Add("@countSelectedRaces", this.selectedRacesInfo["ALL"].Count);

                        foreach (string variable in FormulaVariableList.GetList())
                        {
                            string propertyName = variable.Replace("@", "").CapitilizeFirstChar();

                            PropertyInfo pi = DriverStatsType.GetProperty(propertyName);
                            object val = pi.GetValue(statAll, null);

                            variables.Add(variable, val);
                        }

                            
                        d.Ratings = new Ratings();

                        d.Ratings.GetRating("dr_aggr").Min = this.EvalFormulaToInteger(formula.DriverAggressionMin, variables, "DriverAggressionMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_aggr").Max = this.EvalFormulaToInteger(formula.DriverAggressionMax, variables, "DriverAggressionMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_cons").Min = this.EvalFormulaToInteger(formula.DriverConsistencyMin, variables, "DriverConsistencyMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_cons").Max = this.EvalFormulaToInteger(formula.DriverConsistencyMax, variables, "DriverConsistencyMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_fin").Min = this.EvalFormulaToInteger(formula.DriverFinishingMin, variables, "DriverFinishingMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_fin").Max = this.EvalFormulaToInteger(formula.DriverFinishingMax, variables, "DriverFinishingMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_qual").Min = this.EvalFormulaToInteger(formula.DriverQualifyingMin, variables, "DriverQualifyingMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_qual").Max = this.EvalFormulaToInteger(formula.DriverQualifyingMax, variables, "DriverQualifyingMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_rc").Min = this.EvalFormulaToInteger(formula.DriverRoadCourseMin, variables, "DriverRoadCourseMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_rc").Max = this.EvalFormulaToInteger(formula.DriverRoadCourseMax, variables, "DriverRoadCourseMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_st").Min = this.EvalFormulaToInteger(formula.DriverShortTrackMin, variables, "DriverShortTrackMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_st").Max = this.EvalFormulaToInteger(formula.DriverShortTrackMax, variables, "DriverShortTrackMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_sw").Min = this.EvalFormulaToInteger(formula.DriverSpeedwayMin, variables, "DriverSpeedwayMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_sw").Max = this.EvalFormulaToInteger(formula.DriverSpeedwayMax, variables, "DriverSpeedwayMax", formula.IsProtected);

                        d.Ratings.GetRating("dr_ss").Min = this.EvalFormulaToInteger(formula.DriverSuperSpeedwayMin, variables, "DriverSuperSpeedwayMin", formula.IsProtected);
                        d.Ratings.GetRating("dr_ss").Max = this.EvalFormulaToInteger(formula.DriverSuperSpeedwayMax, variables, "DriverSuperSpeedwayMax", formula.IsProtected);

                        d.Ratings.GetRating("veh_aero").Min = this.EvalFormulaToInteger(formula.VehicleAeroMin, variables, "VehicleAeroMin", formula.IsProtected);
                        d.Ratings.GetRating("veh_aero").Max = this.EvalFormulaToInteger(formula.VehicleAeroMax, variables, "VehicleAeroMax", formula.IsProtected);

                        d.Ratings.GetRating("veh_chas").Min = this.EvalFormulaToInteger(formula.VehicleChassisMin, variables, "VehicleChassisMin", formula.IsProtected);
                        d.Ratings.GetRating("veh_chas").Max = this.EvalFormulaToInteger(formula.VehicleChassisMax, variables, "VehicleChassisMax", formula.IsProtected);

                        d.Ratings.GetRating("veh_eng").Min = this.EvalFormulaToInteger(formula.VehicleEngineMin, variables, "VehicleEngineMin", formula.IsProtected);
                        d.Ratings.GetRating("veh_eng").Max = this.EvalFormulaToInteger(formula.VehicleEngineMax, variables, "VehicleEngineMax", formula.IsProtected);

                        d.Ratings.GetRating("veh_rel").Min = this.EvalFormulaToInteger(formula.VehicleReliabilityMin, variables, "VehicleReliabilityMin", formula.IsProtected);
                        d.Ratings.GetRating("veh_rel").Max = this.EvalFormulaToInteger(formula.VehicleReliabilityMax, variables, "VehicleReliabilityMax", formula.IsProtected);

                        d.Ratings.GetRating("pc_cons").Min = this.EvalFormulaToInteger(formula.PitcrewConsistencyMin, variables, "PitcrewConsistencyMin", formula.IsProtected);
                        d.Ratings.GetRating("pc_cons").Max = this.EvalFormulaToInteger(formula.PitcrewConsistencyMax, variables, "PitcrewConsistencyMax", formula.IsProtected);

                        d.Ratings.GetRating("pc_spe").Min = this.EvalFormulaToInteger(formula.PitcrewSpeedMin, variables, "PitcrewSpeedMin", formula.IsProtected);
                        d.Ratings.GetRating("pc_spe").Max = this.EvalFormulaToInteger(formula.PitcrewSpeedMax, variables, "PitcrewSpeedMax", formula.IsProtected);

                        d.Ratings.GetRating("pc_strat").Min = this.EvalFormulaToInteger(formula.PitcrewStrategyMin, variables, "PitcrewStrategyMin", formula.IsProtected);
                        d.Ratings.GetRating("pc_strat").Max = this.EvalFormulaToInteger(formula.PitcrewStrategyMax, variables, "PitcrewStrategyMax", formula.IsProtected);

                    }

                    this.realDrivers.Add(d);
                 
                }

                this.realDrivers.Sort();
            }
            catch (Exception ex)
            {
                DataProcessingException dpEx = new DataProcessingException(ex.Message, this.selectedRaces, this.selectedFormula);
                this.dataProcessingException = dpEx;
            }

        }

            
        private List<DriverStats> ComputeDriverStats(List<DriverRaceData> driverRaceDataList, List<RaceInfo> racesInfo, CarMappingMethod mappingMethod)
        {
            //CALCULATE PITSTOP RANK
            Dictionary<Race, decimal?> pitStopTimes = new Dictionary<Race, decimal?>();

            foreach (RaceInfo r in racesInfo)
            {
                int position = 1;

                List<DriverRaceData> drdList = (from drd in driverRaceDataList
                                                where drd.Race.Id == r.Race.Id
                                                && drd.PitStopData != null
                                                && drd.PitStopData.AverageTime != null
                                                orderby drd.PitStopData.AverageTime ascending
                                                select drd).ToList();

                foreach(DriverRaceData drd in drdList)
                {
                    drd.PitStopRank = position;
                    position++;
                }
 
            }
            //END CALCULATE PITSTOP RANK


            List<DriverStats> stats = (from drd in driverRaceDataList
                                       group drd by new { drd.RaceResult.CarNumber, drd.RaceResult.Driver } into gr
                                       from drd in gr
                                       orderby gr.Average(drd2 => drd2.RaceResult.FinishPosition).Round(4) ascending
                                       select new DriverStats
                                       {
                                           CarNumber = drd.RaceResult.CarNumber,
                                           Driver = drd.Driver,
                                           AvgFinish = gr.Average(drd2 => (int?)drd2.RaceResult.FinishPosition).Round(4),
                                           AvgFinishExcludingDnf = gr.Where(drd2 => drd2.RaceResult.RaceState.IsDNF == false).Average(drd2 => (int?)drd2.RaceResult.FinishPosition).Round(4),
                                           LeadLapFinishes = (from drd2 in gr
                                                              join rinf in racesInfo on drd2.Race.Id equals rinf.Race.Id
                                                              where drd2.RaceResult.Laps == rinf.WinnerLaps
                                                              select drd2).Count(),
                                           AvgStart = gr.Average(drd2 => drd2.RaceResult.StartPosition).Round(4),
                                           BestFinish = (from drd2 in gr
                                                         where drd2.RaceResult != null
                                                         select drd2.RaceResult.FinishPosition).Min(),
                                           BestStart = (from drd2 in gr
                                                         where drd2.RaceResult != null
                                                         select drd2.RaceResult.StartPosition).Min(),
                                           RaceStarts = gr.Count(),
                                           PercRaceStarts = ((gr.Count() * 1.0) / (racesInfo.Count() * 1.0)).Round(4),
                                           AvgNumberOfStarters = (from drd2 in gr
                                                                  join rinf in racesInfo on drd2.Race.Id equals rinf.Race.Id
                                                                  select rinf.NumberOfStarters).Average().Round(4),
                                           Wins = (from drd2 in gr where drd2.RaceResult.FinishPosition == 1 select drd2).Count(),
                                           Poles = (from drd2 in gr where drd2.RaceResult.StartPosition == 1 select drd2).Count(),
                                           Top5 = (from drd2 in gr where drd2.RaceResult.FinishPosition <= 5 select drd2).Count(),
                                           Top10 = (from drd2 in gr where drd2.RaceResult.FinishPosition <= 10 select drd2).Count(),
                                           DnfCrash = (from drd2 in gr where drd2.RaceResult.RaceState.IsDNFCrash select drd2).Count(),
                                           DnfMechanical = (from drd2 in gr where drd2.RaceResult.RaceState.IsDNFMechanical select drd2).Count(),
                                           PercLapsCompleted = (from drd2 in gr
                                                                join rinf in racesInfo on drd2.Race.Id equals rinf.Race.Id
                                                                select (drd2.RaceResult.Laps * 1.0) / (rinf.WinnerLaps * 1.0)).Average().Round(4),
                                           PercLapsLed = (from drd2 in gr
                                                          join rinf in racesInfo on drd2.Race.Id equals rinf.Race.Id
                                                          select (drd2.RaceResult.LapsLed * 1.0) / (rinf.WinnerLaps * 1.0)).Average().Round(4),
                                           AvgMidRacePosition = (from drd2 in gr
                                                                 where drd2.LoopData != null
                                                                 select drd2.LoopData.MidRacePosition).Average().Round(4),
                                           AvgHighestPosition = (from drd2 in gr
                                                                 where drd2.LoopData != null
                                                                 select drd2.LoopData.HighestPosition).Average().Round(4),
                                           AvgLowestPosition = (from drd2 in gr
                                                                where drd2.LoopData != null
                                                                select drd2.LoopData.LowestPosition).Average().Round(4),
                                           AvgPosition = (from drd2 in gr
                                                          where drd2.LoopData != null
                                                          select drd2.LoopData.AveragePosition).Average().Round(4),
                                           AvgGreenFlagPasses = (from drd2 in gr
                                                                  where drd2.LoopData != null
                                                                  select drd2.LoopData.GreenFlagPasses).Average().Round(4),
                                           AvgGreenFlagPassed = (from drd2 in gr
                                                                 where drd2.LoopData != null
                                                                 select drd2.LoopData.GreenFlagPassed).Average().Round(4),
                                           AvgQualityPasses = (from drd2 in gr
                                                               where drd2.LoopData != null
                                                               select drd2.LoopData.QualityPasses).Average().Round(4),
                                           AvgPercQualityPasses = (from drd2 in gr
                                                                   where drd2.LoopData != null
                                                                   select
                                                                   drd2.LoopData.GreenFlagPasses == 0 ? 0 : (drd2.LoopData.QualityPasses * 1.0) / (drd2.LoopData.GreenFlagPasses * 1.0)).Average().Round(4),
                                           AvgFastestLaps = (from drd2 in gr
                                                             where drd2.LoopData != null
                                                             select drd2.LoopData.FastestLaps).Average().Round(4),
                                           AvgPercFastestLaps = (from drd2 in gr
                                                                 where drd2.LoopData != null
                                                                 select (drd2.LoopData.FastestLaps * 1.0) / (drd2.RaceResult.Laps * 1.0)).Average().Round(4),
                                           AvgTop15Laps = (from drd2 in gr
                                                           where drd2.LoopData != null
                                                           select drd2.LoopData.Top15Laps).Average().Round(4),
                                           AvgPercTop15Laps = (from drd2 in gr
                                                               where drd2.LoopData != null
                                                               select (drd2.LoopData.Top15Laps * 1.0) / (drd2.RaceResult.Laps * 1.0)).Average().Round(4),
                                           AvgRating = (from drd2 in gr
                                                        where drd2.LoopData != null
                                                        select drd2.LoopData.Rating / 150.0).Average().Round(4),
                                           AvgPitStopTimeRank = gr.Average(drd2 => drd2.PitStopRank).Round(4),
                                           RacesInGarage = ((
                                                            (from drd2 in gr
                                                                where drd2.PitStopData != null
                                                                select drd2.PitStopData.InGarage.ToInt() * new int?(1)).NullableSum()
                                                            )),
                                           PercRacesInGarage = ((
                                                                (from drd2 in gr
                                                                    where drd2.PitStopData != null
                                                                    select (drd2.PitStopData.InGarage.ToInt() * new double?(1.0)) / (gr.Count() * 1.0)).NullableSum().Round(4)
                                                                ))                                    
                                       })
                                       .Distinct(new DriverStatsComparerByNumberAndName())
                                       .ToList();

            if (mappingMethod == CarMappingMethod.NAME)
            {
                stats = (from s in stats
                         group s by s.Driver into gr
                         from s in gr
                         orderby gr.Average(s2 => s2.AvgFinish).Round(4) ascending
                         select new DriverStats
                         {
                             CarNumber = null,
                             Driver = s.Driver,
                             AvgFinish = gr.Average(s2 => s2.AvgFinish).Round(4),
                             AvgFinishExcludingDnf = gr.Average(s2 => s2.AvgFinishExcludingDnf).Round(4),
                             LeadLapFinishes = gr.Sum(s2 => s2.LeadLapFinishes),
                             AvgStart = gr.Average(s2 => s2.AvgStart).Round(4),
                             BestFinish = gr.Min(s2 => s2.BestFinish),
                             BestStart = gr.Min(s2 => s2.BestStart),
                             RaceStarts = gr.Sum(s2 => s2.RaceStarts),
                             PercRaceStarts = gr.Sum(s2 => s2.PercRaceStarts),
                             AvgNumberOfStarters = gr.Average(s2 => s2.AvgNumberOfStarters).Round(4),
                             Wins = gr.Sum(s2 => s2.Wins),
                             Poles = gr.Sum(s2 => s2.Poles),
                             Top5 = gr.Sum(s2 => s2.Top5),
                             Top10 = gr.Sum(s2 => s2.Top10),
                             DnfCrash = gr.Sum(s2 => s2.DnfCrash),
                             DnfMechanical = gr.Sum(s2 => s2.DnfMechanical),
                             PercLapsCompleted = gr.Average(s2 => s2.PercLapsCompleted).Round(4),
                             PercLapsLed = gr.Average(s2 => s2.PercLapsLed).Round(4),
                             AvgMidRacePosition = gr.Average(s2 => s2.AvgMidRacePosition).Round(4),
                             AvgHighestPosition = gr.Average(s2 => s2.AvgHighestPosition).Round(4),
                             AvgLowestPosition = gr.Average(s2 => s2.AvgLowestPosition).Round(4),
                             AvgPosition = gr.Average(s2 => s2.AvgPosition).Round(4),
                             AvgGreenFlagPasses = gr.Average(s2 => s2.AvgGreenFlagPasses).Round(4),
                             AvgGreenFlagPassed = gr.Average(s2 => s2.AvgGreenFlagPassed).Round(4),
                             AvgQualityPasses = gr.Average(s2 => s2.AvgQualityPasses).Round(4),
                             AvgPercQualityPasses = gr.Average(s2 => s2.AvgPercQualityPasses).Round(4),
                             AvgFastestLaps = gr.Average(s2 => s2.AvgFastestLaps).Round(4),
                             AvgPercFastestLaps = gr.Average(s2 => s2.AvgPercFastestLaps).Round(4),
                             AvgTop15Laps = gr.Average(s2 => s2.AvgTop15Laps).Round(4),
                             AvgPercTop15Laps = gr.Average(s2 => s2.AvgPercTop15Laps).Round(4),
                             AvgRating = gr.Average(s2 => s2.AvgRating).Round(4),
                             AvgPitStopTimeRank = gr.Average(s2 => s2.AvgPitStopTimeRank).Round(4),
                             RacesInGarage = (from s2 in gr select s2.RacesInGarage * new int?(1)).NullableSum(),
                             PercRacesInGarage = gr.Average(s2 => s2.PercRacesInGarage).Round(4)
                         })
                         .Distinct(new DriverStatsComparerByNumberAndName())
                         .ToList();
            }
            else if (mappingMethod == CarMappingMethod.NUMBER)
            {
                stats = (from s in stats
                         group s by s.CarNumber into gr
                         from s in gr
                         orderby gr.Average(s2 => s2.AvgFinish).Round(4) ascending
                         select new DriverStats
                         {
                             CarNumber = s.CarNumber,
                             Driver = null,
                             AvgFinish = gr.Average(s2 => s2.AvgFinish).Round(4),
                             AvgFinishExcludingDnf = gr.Average(s2 => s2.AvgFinishExcludingDnf).Round(4),
                             LeadLapFinishes = gr.Sum(s2 => s2.LeadLapFinishes),
                             AvgStart = gr.Average(s2 => s2.AvgStart).Round(4),
                             BestFinish = gr.Min(s2 => s2.BestFinish),
                             BestStart = gr.Min(s2 => s2.BestStart),
                             RaceStarts = gr.Sum(s2 => s2.RaceStarts),
                             PercRaceStarts = gr.Sum(s2 => s2.PercRaceStarts),
                             AvgNumberOfStarters = gr.Average(s2 => s2.AvgNumberOfStarters).Round(4),
                             Wins = gr.Sum(s2 => s2.Wins),
                             Poles = gr.Sum(s2 => s2.Poles),
                             Top5 = gr.Sum(s2 => s2.Top5),
                             Top10 = gr.Sum(s2 => s2.Top10),
                             DnfCrash = gr.Sum(s2 => s2.DnfCrash),
                             DnfMechanical = gr.Sum(s2 => s2.DnfMechanical),
                             PercLapsCompleted = gr.Average(s2 => s2.PercLapsCompleted).Round(4),
                             PercLapsLed = gr.Average(s2 => s2.PercLapsLed).Round(4),
                             AvgMidRacePosition = gr.Average(s2 => s2.AvgMidRacePosition).Round(4),
                             AvgHighestPosition = gr.Average(s2 => s2.AvgHighestPosition).Round(4),
                             AvgLowestPosition = gr.Average(s2 => s2.AvgLowestPosition).Round(4),
                             AvgPosition = gr.Average(s2 => s2.AvgPosition).Round(4),
                             AvgGreenFlagPasses = gr.Average(s2 => s2.AvgGreenFlagPasses).Round(4),
                             AvgGreenFlagPassed = gr.Average(s2 => s2.AvgGreenFlagPassed).Round(4),
                             AvgQualityPasses = gr.Average(s2 => s2.AvgQualityPasses).Round(4),
                             AvgPercQualityPasses = gr.Average(s2 => s2.AvgPercQualityPasses).Round(4),
                             AvgFastestLaps = gr.Average(s2 => s2.AvgFastestLaps).Round(4),
                             AvgPercFastestLaps = gr.Average(s2 => s2.AvgPercFastestLaps).Round(4),
                             AvgTop15Laps = gr.Average(s2 => s2.AvgTop15Laps).Round(4),
                             AvgPercTop15Laps = gr.Average(s2 => s2.AvgPercTop15Laps).Round(4),
                             AvgRating = gr.Average(s2 => s2.AvgRating).Round(4),
                             AvgPitStopTimeRank = gr.Average(s2 => s2.AvgPitStopTimeRank).Round(4),
                             RacesInGarage = (from s2 in gr select s2.RacesInGarage * new int?(1)).NullableSum(),
                             PercRacesInGarage = gr.Average(s2 => s2.PercRacesInGarage).Round(4)
                         })
                         .Distinct(new DriverStatsComparerByNumberAndName())
                         .ToList();
            }

            return stats;
        }


        private Dictionary<string, DriverStats> GetSingleDriverStatsByType(Dictionary<string, List<DriverStats>> driverStatsByType, CarMappingMethod mappingMethod, string carNumber, Driver driver)
        {
            Dictionary<string, DriverStats> statsByType = new Dictionary<string, DriverStats>();

            foreach (TrackType tt in trackTypes)
            {

                var q = from s in driverStatsByType[tt.Id]
                        select s;

                switch (mappingMethod)
                {
                    case CarMappingMethod.NAME:
                        q = from s in q
                            where s.Driver == driver
                            select s;
                        break;
                    case CarMappingMethod.NUMBER:
                        q = from s in q
                            where s.CarNumber == carNumber
                            select s;    
                        break;
                    case CarMappingMethod.NUMBER_AND_NAME:
                        q = from s in q
                            where s.Driver == driver
                            && s.CarNumber == carNumber
                            select s;
                        break;
                }

                
                DriverStats stats = q.FirstOrDefault();

                //IF NO STATS WERE FOUND FOR THIS DRIVER FOR THIS TRACKTYPE, INITIALIZE AN EMPTY DRIVERSTATS
                if (stats == null)
                {
                    stats = new DriverStats();
                }

                statsByType.Add(tt.Id, stats);
            }

            return statsByType;
        }

        private int EvalFormulaToInteger(string formula, Dictionary<string, object> variables, string sender, bool isProtectedFormula)
        {
            JPackage.Eval ev = new JPackage.Eval();

            string separator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            //Console.WriteLine(separator);

            string expression = this.ReplaceVariables(formula, variables, separator);
            //Console.WriteLine(expression + " = " + ev.DoEval(expression));


            string result = null;

            try
            {
                result = ev.DoEval(expression).Replace(".", separator).Replace(",", separator);

                if(result.ToLower().Equals("infinity"))
                    throw new Exception("Division by zero !");
            }
            catch (Exception ex)
            {
                string error = "There was an error compiling the formula";

                if (!isProtectedFormula)
                {
                    error = "Could not compile the formula for " + sender + ": \r\n\r\n" +
                             formula + "\r\n\r\n" +
                             "After filling in the variables for one of the drivers, this is the expression: \r\n\r\n" +
                             expression + "\r\n\r\n" +
                             "The returned error was: " + ex.ToString();
                }

                throw new Exception(error);
            }

            double dblResult = Convert.ToDouble(result);

            return Convert.ToInt32(Math.Round(dblResult, 0));
        }

        private string ReplaceVariables(string toReplace, Dictionary<string, object> variables, string separator)
        {
            foreach (string s in variables.Keys)
            {
                string v;

                if (variables[s] == null)
                    v = "null";
                else
                    v = Convert.ToString(variables[s]).Replace(separator, ".");

                
                toReplace = toReplace.Replace(s, v);
            }

            return toReplace;

        }
 
    }
}
