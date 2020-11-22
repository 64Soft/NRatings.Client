using System;
using System.Collections.Generic;
using NRatings.Client.Extension;

namespace NRatings.Client.Domain
{
    /// <summary>
    /// All stats are related to the races where the driver took part in
    /// </summary>
    public class DriverStats
    {
        //RACERESULTS
        public string CarNumber { get; set; }
        public Driver Driver { get; set; }

        /// <summary>
        /// Average finish position
        /// </summary>
        public double? AvgFinish { get; set; }

        /// <summary>
        /// Average finish position excluding DNF finishes
        /// </summary>
        public double? AvgFinishExcludingDnf { get; set; }

        /// <summary>
        /// Average starting position
        /// </summary>
        public double? AvgStart { get; set; }

        /// <summary>
        /// Best finish position
        /// </summary>
        public int? BestFinish { get; set; }

        /// <summary>
        /// Best starting position
        /// </summary>
        public int? BestStart { get; set; }

        /// <summary>
        /// Number of race starts
        /// </summary>
        public int? RaceStarts { get; set; }

        /// <summary>
        /// Percentage of race starts
        /// </summary>
        public double? PercRaceStarts { get; set; }

        /// <summary>
        /// Average number of starters
        /// </summary>
        public double? AvgNumberOfStarters { get; set; }

        /// <summary>
        /// Number of lead lap finishes
        /// </summary>
        public int? LeadLapFinishes { get; set; }

        /// <summary>
        /// Number of wins
        /// </summary>
        public int? Wins { get; set; }

        /// <summary>
        /// Number of pole positions
        /// </summary>
        public int? Poles { get; set; }

        /// <summary>
        /// Number of top 5 finishes
        /// </summary>
        public int? Top5 { get; set; }

        /// <summary>
        /// Number of top 10 finishes
        /// </summary>
        public int? Top10 { get; set; }

        /// <summary>
        /// Number of DNFs due a crash or spin
        /// </summary>
        public int? DnfCrash { get; set; }

        /// <summary>
        /// Number of DNFs due to a mechanical problem
        /// </summary>
        public int? DnfMechanical { get; set; }

        /// <summary>
        /// Percentage of laps completed
        /// </summary>
        public double? PercLapsCompleted { get; set; }

        /// <summary>
        /// Percentage of laps led
        /// </summary>
        public double? PercLapsLed { get; set; }

        /// <summary>
        /// Total number of DNFs, whatever the reason
        /// </summary>
        public int? Dnf
        {
            get { return DnfCrash + DnfMechanical; }
        }

        /// <summary>
        /// Percentage of lead lap finishes
        /// </summary>
        public double? PercLeadLapFinishes
        {
            get
            {
                return ((LeadLapFinishes*1.0)/(RaceStarts*1.0)).Round(4);
            }
        }

        /// <summary>
        /// The closer to 1, the higher the average finish is compared to the average number of starters.
        /// 1 means winning all races (= average finish position of 1)
        /// </summary>
        public double? FinishCoefficient
        {
            get
            {
                var spread = 1.0/AvgNumberOfStarters;

                return (1 - ((AvgFinish - 1)*spread)).Round(4);
            }
        }

        /// <summary>
        /// The closer to 1, the higher the average starting position is compared to the average number of starters.
        /// 1 means pole position in all races (= average starting position of 1)
        /// </summary>
        public double? StartCoefficient
        {
            get
            {
                var spread = 1.0 / AvgNumberOfStarters;

                return (1 - ((AvgStart - 1) * spread)).Round(4);
            }
        }


        //LOOPDATA
        public double? AvgMidRacePosition { get; set; }
        public double? AvgHighestPosition { get; set; }
        public double? AvgLowestPosition { get; set; }
        public double? AvgPosition { get; set; } //AVERAGE OF AVERAGE POSITION DURING A RACE
        public double? AvgGreenFlagPasses { get; set; }
        public double? AvgGreenFlagPassed { get; set; }
        public double? AvgQualityPasses { get; set; } //GREEN FLAG PASSES INSIDE TOP15
        public double? AvgPercQualityPasses { get; set; } //AVERAGE OF PERCENTAGE OF QUALITY PASSES --> Green flag passes that are made inside TOP15
        public double? AvgFastestLaps { get; set; }
        public double? AvgPercFastestLaps { get; set; } //AVERAGE OF PERCENTAGE OF FASTEST LAPS IN A RACE
        public double? AvgTop15Laps { get; set; }
        public double? AvgPercTop15Laps { get; set; } //AVERAGE OF PERCENTAGE OF LAPS RAN IN THE TOP 15 IN A RACE
        public double? AvgRating { get; set; }


        //PITSTOPDATA
        public double? AvgPitStopTimeRank { get; set; } //AVERAGE POSITION OF AVERAGE PITSTOPTIME IN A RACE
        public int? RacesInGarage { get; set; }
        public double? PercRacesInGarage { get; set; } //PERCENTAGE OF RACES WHERE TIME WAS SPENT IN GARAGE


    }

    public class DriverStatsComparerByNumberAndName : IEqualityComparer<DriverStats>
    {
        #region IEqualityComparer<DriverStats> Members

        public bool Equals(DriverStats x, DriverStats y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else
            {

                string carNumberX = string.Empty;
                string carNumberY = string.Empty;

                if (x.CarNumber != null)
                    carNumberX = x.CarNumber;

                if (y.CarNumber != null)
                    carNumberY = y.CarNumber;

                return carNumberX.Equals(carNumberY) &&
                        x.Driver == y.Driver;
            }
        }

        public int GetHashCode(DriverStats obj)
        {
            string carnumber = String.Empty;
            int driverId = 0;

            if (obj.CarNumber != null)
                carnumber = obj.CarNumber;

            if (obj.Driver != null)
                driverId = obj.Driver.Id;

            return (
                    carnumber +
                    driverId.ToString()
                   ).GetHashCode();
        }

        #endregion
    }

    public class DriverStatsComparer : IEqualityComparer<DriverStats>
    {
        #region IEqualityComparer<DriverStats> Members

        public bool Equals(DriverStats x, DriverStats y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else
            {

                string carNumberX = string.Empty;
                string carNumberY = string.Empty;

                if (x.CarNumber != null)
                    carNumberX = x.CarNumber;

                if (y.CarNumber != null)
                    carNumberY = y.CarNumber;

                return carNumberX.Equals(carNumberY) &&
                        x.Driver == y.Driver &&
                        x.AvgFinish == y.AvgFinish &&
                        x.AvgStart == y.AvgStart &&
                        x.RaceStarts == y.RaceStarts &&
                        x.Wins == y.Wins &&
                        x.Top5 == y.Top5 &&
                        x.Top10 == y.Top10 &&
                        x.Dnf == y.Dnf &&
                        x.DnfCrash == y.DnfCrash &&
                        x.DnfMechanical == y.DnfMechanical &&
                        x.PercLapsCompleted == y.PercLapsCompleted &&
                        x.PercLapsLed == y.PercLapsLed;
            }
        }

        public int GetHashCode(DriverStats obj)
        {
            string carnumber = String.Empty;
            int driverId = 0;
            double avgStart = 0;

            if (obj.CarNumber != null)
                carnumber = obj.CarNumber;

            if (obj.Driver != null)
                driverId = obj.Driver.Id;
            
            if (obj.AvgStart.HasValue)
                avgStart = obj.AvgStart.Value;

            return (
                    carnumber +
                    driverId.ToString() +
                    obj.AvgFinish.ToString() +
                    avgStart.ToString() +
                    obj.RaceStarts.ToString() +
                    obj.Wins.ToString() +
                    obj.Top5.ToString() +
                    obj.Top10.ToString() +
                    obj.Dnf.ToString() +
                    obj.DnfCrash.ToString() +
                    obj.DnfMechanical.ToString() +
                    obj.PercLapsCompleted.ToString() +
                    obj.PercLapsLed.ToString()                    
                   ).GetHashCode();
        }

        #endregion
    }
}
