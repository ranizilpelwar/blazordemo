using System.Timers;

namespace blazordemo.Adapters
{
	public class PomTimer : IPomTimer
	{
        private System.Timers.Timer timer;

		public PomTimer()
		{
            timer = new System.Timers.Timer(1 * 1000);
		}

        double IPomTimer.Interval
        {
            get
            {
                return timer.Interval;
            }

            set => timer.Interval = value;
        }

        event ElapsedEventHandler IPomTimer.Elapsed
        {
            add { timer.Elapsed += value; }
            remove { timer.Elapsed -= value; }
        }

        void IPomTimer.Start()
        {
            timer.Start();
        }

        void IPomTimer.Stop()
        {
            timer.Stop();
        }
    }
}

