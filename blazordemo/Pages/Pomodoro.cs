using System.Timers;
using blazordemo.Adapters;

namespace blazordemo.Pages
{
	public partial class Pomodoro
	{
        public Pomodoro()
        {
            _timer = new PomTimer();
        }

        public Pomodoro(IPomTimer timer)
        {
            _timer = timer;
        }
        private IPomTimer _timer;
        public String MinutesLeft { get; set; } = "00";
        public String SecondsLeft { get; set; } = "00";
        private int _timeLeft = 20 * 60;
        public int TimeLeft { get => _timeLeft; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _timer.Elapsed += OnTimedEvent;
        }

        public void StartTimer()
        {
            Console.WriteLine("starting timer");
            _timer.Start();
            Console.WriteLine("started timer");
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _timeLeft--;
            Console.WriteLine(_timeLeft);
            MinutesLeft = (_timeLeft / 60).ToString("00");
            SecondsLeft = (_timeLeft % 60).ToString("00");
            StateHasChanged();
        }

        //public String MinutesLeft { get; set; }
        //      public String SecondsLeft { get; set; }
        //private int _timeLeft = 0;
        //public int TimeLeft { get => _timeLeft; }

        //private IPomTimer Timer;

        //      public Pomodoro(IPomTimer timer)
        //{
        //	MinutesLeft = "00";
        //          SecondsLeft = "00";
        //	Timer = timer;
        //	Timer.Elapsed += OnTimedEvent;
        //	_timeLeft = 20 * 60;
        //      }

        //public void StartTimer()
        //{
        //          Console.WriteLine("starting timer");
        //          Timer.Start();
        //          Console.WriteLine("started timer");
        //      }

        //      private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //      {
        //          _timeLeft--;
        //          Console.WriteLine(_timeLeft);
        //          MinutesLeft = (_timeLeft / 60).ToString("00");
        //          SecondsLeft = (_timeLeft % 60).ToString("00");
        //      }
    }
}

