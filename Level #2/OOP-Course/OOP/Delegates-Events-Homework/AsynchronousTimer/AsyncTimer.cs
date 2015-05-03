namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    class AsyncTimer
    {
        private Action<string> action;
        private int interval;
        private int ticks;

        public AsyncTimer(Action<string> action, int interval, int ticks)
        {
            this.Action = action;
            this.Interval = interval;
            this.Ticks = ticks;
        }

        public Action<string> Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interval must be positive.");
                }
                this.interval = value;
            }
        }

        public int Ticks
        {
            get { return this.ticks; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ticks must be positive.");
                }
                this.ticks = value;
            }
        }

        public void Do()
        {
            while (this.ticks > 0)
            {
                Thread.Sleep(this.interval);

                if (this.Action != null)
                {
                    this.Action(this.Ticks + "");
                }

                this.Ticks--;
            }
        }

        public void Start()
        {
            Thread thread = new Thread(this.Do);
            thread.Start();
        }

    }
}
