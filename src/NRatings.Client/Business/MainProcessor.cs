using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain.Collections;
using NRatings.Client.EventHandling;
using NRatings.Client.Validation;

namespace NRatings.Client.Business
{
    public class MainProcessor
    {
        private bool VersionCheckInteractive = false;

        private RealDriverCollection realDrivers;

        public event EventHandler<EventArgs<bool>> NewsCheckingFinished;
        public event EventHandler RealDriverCollectionChanged;
        public event EventHandler<EventArgs<Message>> MessageRaised;

        public RealDriverCollection RealDrivers
        {
            get { return this.realDrivers; }
            set
            {
                this.realDrivers = value;

                if (this.RealDriverCollectionChanged != null)
                    this.RealDriverCollectionChanged(this, null);
            }
        }

        private void OnMessageRaised(Message message)
        {
            if (this.MessageRaised != null)
                this.MessageRaised(this, new EventArgs<Message>(message));
        }
    }
}
