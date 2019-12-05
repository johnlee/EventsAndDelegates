using System;
namespace DnetDelegates
{
    public class Events
    {
        public Events()
        {
        }
    }

    // The Event
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted; // .nets built in EventHandler

        public void DoWork(int hours)
        {
            OnWorkPerformed(hours);
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours)
        {
            var wp = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (wp != null)
            {
                wp(this, new WorkPerformedEventArgs(hours));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            var wc = WorkCompleted as EventHandler;
            if (wc != null)
            {
                wc(this, EventArgs.Empty);
            }
        }
    }

    // The EventArgs
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours)
        {
            Hours = hours;
        }

        public int Hours { get; set; }
    }
}
