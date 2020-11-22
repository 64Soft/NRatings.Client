using System;
using System.Collections.Generic;
using System.Linq;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;

namespace NRatings.Client.Business
{
    public class RatingsModifier
    {
        private CarCollection mCarCollection;
        private NR2003Car mCurrentCar;

        private List<NR2003Car> mTargetCars;
        private List<string> mTargetRatingsKeys;
        private RatingsTypeToModify mTargetRatingsType;
        private ActionToPerform mTargetAction;
        private bool mGroupByNumber = false;
        private bool mGroupByName = false;
        private int? mMinValue;
        private int? mMaxValue;
        private decimal? mValue;


        public CarCollection CarCollection
        {
            get { return this.mCarCollection; }
            set { this.mCarCollection = value; }
        }

        public NR2003Car CurrentCar
        {
            get { return this.mCurrentCar; }
            set { this.mCurrentCar = value; }
        }

        public enum CarsToModify
        {
            Current = 1,
            Selected = 2,
            All = 3

        };

        public enum RatingsTypeToModify
        {
            Min = 1,
            Max = 2,
            Both = 3
        };

        public enum ActionToPerform
        {
            Randomize = 1,
            Add = 2,
            Multiply = 3,
            Set = 4
        };



        public int GetSelectedCarCount()
        {
            int ret = 0;
            if (this.mCarCollection != null)
            {
                ret = this.mCarCollection.GetSelectedCount();
            }

            return ret;
        }

        public void SetTargetRatings(List<string> targetRatingsKeys)
        {
            this.mTargetRatingsKeys = targetRatingsKeys;
        }

        public void SetTargetRatingsType(RatingsTypeToModify toModify)
        {
            this.mTargetRatingsType = toModify;
        }

        public void SetTargetCars(CarsToModify toModify)
        {
            this.mTargetCars = new List<NR2003Car>();

            switch (toModify)
            {
                case CarsToModify.Current:
                    this.mTargetCars.Add(this.mCurrentCar);

                    break;

                case CarsToModify.Selected:
                    this.mTargetCars = this.mCarCollection.GetSelectedCars();

                    break;

                case CarsToModify.All:
                    this.mTargetCars = this.mCarCollection;

                    break;

            }

        }

        public void SetTargetAction(ActionToPerform action)
        {
            this.mTargetAction = action;
        }

        public void SetGroupingOptions(bool groupByNumber, bool groupByName)
        {
            this.mGroupByNumber = groupByNumber;
            this.mGroupByName = groupByName;
        }

        public void SetVariables(int? minValue, int? maxValue, decimal? value)
        {
            this.mMinValue = minValue;
            this.mMaxValue = maxValue;
            this.mValue = value;
        }

       

        public void ApplyModifications()
        {
            if (this.mTargetCars != null && this.mTargetRatingsKeys != null)
            {
                List<NR2003Car> processedCars = new List<NR2003Car>();

                foreach (NR2003Car c in this.mTargetCars)
                {
                    if (!processedCars.Contains(c))
                    {

                        switch (this.mTargetAction)
                        {
                            case ActionToPerform.Randomize:
                                if (this.mMinValue != null && this.mMaxValue != null)
                                {
                                    foreach (string key in this.mTargetRatingsKeys)
                                    {
                                        int rand1 = Helper.GetRandomNumber(this.mMinValue.Value, this.mMaxValue.Value);
                                        int rand2 = Helper.GetRandomNumber(this.mMinValue.Value, this.mMaxValue.Value);

                                        int smallest;
                                        int largest;

                                        if (rand1 > rand2)
                                        {
                                            largest = rand1;
                                            smallest = rand2;
                                        }
                                        else
                                        {
                                            largest = rand2;
                                            smallest = rand1;
                                        }


                                        if (this.mTargetRatingsType == RatingsTypeToModify.Min)
                                        {
                                            c.Ratings.RatingsList[key].Min = rand1;
                                        }
                                        else if (this.mTargetRatingsType == RatingsTypeToModify.Max)
                                        {
                                            c.Ratings.RatingsList[key].Max = rand1;
                                        }
                                        else if (this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Min = smallest;
                                            c.Ratings.RatingsList[key].Max = largest;
                                        }

                                    }
                                }
                                break;

                            case ActionToPerform.Set:
                                if (this.mValue != null)
                                {
                                    foreach (string key in this.mTargetRatingsKeys)
                                    {
                                        if (this.mTargetRatingsType == RatingsTypeToModify.Min || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Min = (int)(Math.Round(this.mValue.Value, 0));
                                        }
                                        if (this.mTargetRatingsType == RatingsTypeToModify.Max || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Max = (int)(Math.Round(this.mValue.Value, 0));
                                        }
                                    }
                                }
                                break;

                            case ActionToPerform.Add:
                                if (this.mValue != null)
                                {
                                    foreach (string key in this.mTargetRatingsKeys)
                                    {
                                        int origMax = c.Ratings.RatingsList[key].Max;

                                        if (this.mTargetRatingsType == RatingsTypeToModify.Min || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Min += (int)(Math.Round(this.mValue.Value, 0));
                                        }
                                        if (this.mTargetRatingsType == RatingsTypeToModify.Max || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Max = origMax + (int)(Math.Round(this.mValue.Value, 0));
                                        }
                                    }
                                }
                                break;

                            case ActionToPerform.Multiply:
                                if (this.mValue != null)
                                {
                                    foreach (string key in this.mTargetRatingsKeys)
                                    {
                                        int origMax = c.Ratings.RatingsList[key].Max;

                                        if (this.mTargetRatingsType == RatingsTypeToModify.Min || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Min = (int)(Math.Round(c.Ratings.RatingsList[key].Min * this.mValue.Value, 0));
                                        }
                                        if (this.mTargetRatingsType == RatingsTypeToModify.Max || this.mTargetRatingsType == RatingsTypeToModify.Both)
                                        {
                                            c.Ratings.RatingsList[key].Max = (int)(Math.Round(origMax * this.mValue.Value, 0));
                                        }
                                    }
                                }
                                break;

                        }

                        //ADD THIS CAR TO THE LIST OF PROCESSED CARS
                        processedCars.Add(c);

                        //APPLY GROUPING OPTIONS TO SIMILAR UNPROCESSED CARS
                        this.GroupRatings(c, processedCars);
        
                    }
                    else
                    {
                        Console.WriteLine("#" + c.Number + " " + c.DriverFirstName + " " + c.DriverLastName + " (" + c.FileName + ") has already been processed");
                    }
                    
                }
            }

        }

        /// <summary>
        /// Searches cars in targetCars but not in processedCars matching number and/or name (according to grouping options), and updates it with the same ratings.
        /// Then adds modified cars to processedCars (which is updated by reference)
        /// </summary>
        /// <param name="sourceCar"></param>
        /// <param name="processedCars"></param>
        private void GroupRatings(NR2003Car sourceCar, List<NR2003Car> processedCars)
        {
            if(this.mGroupByNumber || this.mGroupByName)
            {
                //SELECT ALL UNPROCESSED CARS FROM COMPLETE CARLIST, DIFFERENT FROM SOURCECAR
                var q = from NR2003Car c in this.mCarCollection
                        where !processedCars.Contains(c) && c != sourceCar
                        select c;

                List<NR2003Car> similarCars = q.ToList();

                if (this.mGroupByNumber)
                    similarCars = similarCars.Where(c => c.Number.Equals(sourceCar.Number)).ToList();

                if(this.mGroupByName)
                    similarCars = similarCars.Where(c => c.DriverFirstName.Equals(sourceCar.DriverFirstName) && c.DriverLastName.Equals(sourceCar.DriverLastName)).ToList();


                foreach (NR2003Car c in similarCars)
                {
                    c.Ratings = (Ratings)sourceCar.Ratings.Clone();
                    processedCars.Add(c);
                }
            }
        }


    }
}
