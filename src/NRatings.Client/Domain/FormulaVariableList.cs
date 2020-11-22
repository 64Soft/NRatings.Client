using System.Collections.Generic;

namespace NRatings.Client.Domain
{
    public static class FormulaVariableList
    {
        private static readonly List<string> variableList = new List<string>
                                                   {
                                                            "@avgFinish",
                                                            "@avgFinishExcludingDnf",
                                                            "@avgStart",
                                                            "@bestFinish",
                                                            "@bestStart",
                                                            "@raceStarts",
                                                            "@percRaceStarts",
                                                            "@avgNumberOfStarters",
                                                            "@leadLapFinishes",
                                                            "@percLeadLapFinishes",
                                                            "@wins",
                                                            "@poles",
                                                            "@top5",
                                                            "@top10",
                                                            "@dnfCrash",
                                                            "@dnfMechanical",
                                                            "@dnf",
                                                            "@percLapsCompleted",
                                                            "@percLapsLed",
                                                            "@finishCoefficient",
                                                            "@startCoefficient",
                                                            "@avgMidRacePosition",
                                                            "@avgHighestPosition",
                                                            "@avgLowestPosition",
                                                            "@avgPosition",
                                                            "@avgGreenFlagPasses",
                                                            "@avgGreenFlagPassed",
                                                            "@avgQualityPasses",
                                                            "@avgPercQualityPasses",
                                                            "@avgFastestLaps",
                                                            "@avgPercFastestLaps",
                                                            "@avgTop15Laps",  
                                                            "@avgPercTop15Laps",
                                                            "@avgRating",
                                                            "@avgPitStopTimeRank",
                                                            "@RacesInGarage",
                                                            "@percRacesInGarage"
                                                    };


        public static List<string> GetList()
        {
            return variableList;
        }

    }
}
