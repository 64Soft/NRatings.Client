using System;
using System.Collections.Generic;

namespace NRatings.Client.Validation
{
    /// <summary>
    /// Used as method return type to return validation information
    /// </summary>
    public class ValidatedResult
    {
        private Exception exception;
        private IList<Message> messages;

        public Exception Exception
        {
            get { return this.exception; }
            set { this.exception = value; }
        }

        public IList<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public ValidatedResult()
        {
            this.messages = new List<Message>();
        }
       
    }

    /// <summary>
    /// Used as method return type to return validation information, along with a return object
    /// </summary>
    /// <typeparam name="T">The type of the return object</typeparam>
    public class ValidatedResult<T> : ValidatedResult
    {
        private T returnObject;

        public T ReturnObject
        {
            get { return returnObject; }
            set { this.returnObject = value; }
        }

        public ValidatedResult() : base()
        {

        }
    }
}
