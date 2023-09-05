using System.Timers;

namespace blazordemo.Adapters
{
    public interface IPomTimer
    {
        void Start();
        void Stop();
        double Interval { get; set; }
        event ElapsedEventHandler Elapsed;
    }
}

