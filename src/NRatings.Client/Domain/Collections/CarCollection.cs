using System;
using System.Collections.Generic;
using System.Linq;
using NRatings.Client.EventHandling;

namespace NRatings.Client.Domain.Collections
{
    public class CarCollection : List<NR2003Car>
    {
        private bool mIsDirty = false;
        public event EventHandler<EventArgs<bool>> IsDirtyChanged;
        
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

        public new void Add(NR2003Car car)
        {
            base.Add(car);

            car.IsDirtyChanged += new EventHandler<EventArgs<bool>>(car_IsDirtyChanged);
        }

        public void RevertToOriginal()
        {
            try
            {
                foreach (NR2003Car car in this)
                {
                    car.RevertToOriginal(NR2003Car.RevertType.Completely);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void car_IsDirtyChanged(object sender, EventArgs<bool> e)
        {
            
            if (e.ArgObject == true) //if one car is dirty, the whole collection is dirty
                this.IsDirty = true;
            else
            {
                //check if other cars are dirty
                var q = from NR2003Car car in this
                        where car.IsDirty == true
                        select car;

                if (q.Count() == 0) //no other cars are dirty
                    this.IsDirty = false;
                else
                    this.IsDirty = true;
            }
        }

        private void OnIsDirtyChanged(bool isDirty)
        {
            if (this.IsDirtyChanged != null)
                this.IsDirtyChanged(this, new EventArgs<bool>(isDirty));
        }

        public int GetSelectedCount()
        {

            var q = from NR2003Car c in this
                    where c.Selected == true
                    select c;

            return q.Count();

        }

        public List<NR2003Car> GetSelectedCars()
        {
            var q = from NR2003Car c in this
                    where c.Selected == true
                    select c;

            return q.ToList();
        }

        public int GetModifiedCount()
        {
            
            var q = from NR2003Car c in this
                    where c.IsDirty == true
                    select c;

            return q.Count();
            
        }

        public List<NR2003Car> GetModifiedCars()
        {
            var q = from NR2003Car c in this
                    where c.IsDirty == true
                    select c;

            return q.ToList();
        }

    }
}
