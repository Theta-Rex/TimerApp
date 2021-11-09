namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Timers;
    using System.Windows.Input;
    using Xamarin.Forms;

    class MyTimer : INotifyPropertyChanged
    {
        public string TimerName { get; set; }
        public string EntryTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        private TimeSpan timeRemaining;
        private Timer timer;

        public MyTimer(string timername, string entrytime)
        {
            this.TimerName = timername;
            this.EntryTime = entrytime;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public TimeSpan TimeRemaining
        {
            get => this.timeRemaining;
            set
            {
                if (this.timeRemaining != value)
                {
                    this.timeRemaining = value;
                    this.OnPropertyChanged(nameof(this.TimeRemaining));
                };

            }
        }

        public ICommand StartTimerCommand => new Command(StartTimer);

        void StartTimer(object o)
        {
            this.StartTime = DateTime.Now;
            TimeSpan t = TimeSpan.FromSeconds(int.Parse(this.EntryTime));
            this.EndTime = this.StartTime + t;

            SystemTimer();

        }
        void SystemTimer()
        {
            this.timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            void OnTimedEvent(object sender, ElapsedEventArgs e)
            {
                this.TimeRemaining = this.EndTime - DateTime.Now;
                if (this.TimeRemaining <= TimeSpan.Zero)
                {
                    this.timer.Stop();
                }
                
            }
        }

    }
}
