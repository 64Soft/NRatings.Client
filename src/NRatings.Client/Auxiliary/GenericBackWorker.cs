using System;
using System.ComponentModel;

namespace NRatings.Client.Auxiliary
{
    public class GenericBackWorker
    {
        private BackgroundWorker backworker;

        public event EventHandler WorkerCompleted;

        public GenericBackWorker()
        {

        }

        public void StartWorker<TResult>(Func<TResult> function)
        {
            if (this.backworker == null || this.backworker.IsBusy == false)
            {

                this.backworker = new BackgroundWorker();
                this.backworker.DoWork += (sender, e) => e.Result = ((Func<TResult>)e.Argument)();
                this.backworker.RunWorkerCompleted += (sender, e) =>
                {
                    if (this.WorkerCompleted != null)
                        this.WorkerCompleted(this, e);

                };
                this.backworker.RunWorkerAsync(function);
            }
        }

        public void StartWorker(Action action)
        {
            if (this.backworker == null || this.backworker.IsBusy == false)
            {
                this.backworker = new BackgroundWorker();
                this.backworker.DoWork += (sender, e) => action();
                this.backworker.RunWorkerCompleted += (sender, e) =>
                {
                    if (this.WorkerCompleted != null)
                        this.WorkerCompleted(this, e);

                };
                this.backworker.RunWorkerAsync(action);
            }
        }

        public void StartWorker(Action workAction, Action finishAction)
        {
            if (this.backworker == null || this.backworker.IsBusy == false)
            {
                this.backworker = new BackgroundWorker();
                this.backworker.DoWork += (sender, e) => workAction();
                this.backworker.RunWorkerCompleted += (sender, e) => finishAction();
                
                this.backworker.RunWorkerAsync(workAction);
            }
        }

    }
}
