using System;
using System.ComponentModel;

namespace NRatings.Client.EventHandling
{
    public class EventArgs<T> : EventArgs
    {
        private T argObject;

        public T ArgObject
        {
            get { return this.argObject; }
        }

        public EventArgs(T argObject)
        {
            this.argObject = argObject;
        }
    }

    public class ProgressChangedEventArgs<T> : ProgressChangedEventArgs
    {
        public new T UserState { get; set; }

        public ProgressChangedEventArgs(int progressPercentage, T argObject)
            : base(progressPercentage, argObject)
        {
            this.UserState = argObject;
        }
    }
}
