// <copyright file="MyTimer.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Timers;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// MyTimer class creates an object for each Timer.
    /// </summary>
    public class MyTimer : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        ///  The update interval of the timer.
        /// </summary>
        private const int TimerInterval = 1000;

        /// <summary>
        /// System timer.
        /// </summary>
        private readonly Timer timer = new Timer() { Enabled = true, Interval = MyTimer.TimerInterval };

        private string playPauseImage;

        /// <summary>
        /// Calculates time remaining which is bound to the label.
        /// </summary>
        private TimeSpan timeRemaining;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimer"/> class.
        /// </summary>
        /// <param name="timername">name of timer.</param>
        /// <param name="entrytime">gets entrytime from user.</param>
        public MyTimer(string timername, string entrytime)
        {
            // Initialize the object.
            this.EntryTime = entrytime;
            this.TimerName = timername;
            this.PlayPauseImage = "Assets/play.png";
        }

        /// <summary>
        /// used for IPropertyNotify.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// gets or sets EndTime.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// gets or sets EntryTime, which is the amount of time entered by the user.
        /// </summary>
        public string EntryTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsRunning is true.
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Gets or sets PlayPauseImage for propertychange.
        /// </summary>
        public string PlayPauseImage
        {
            get => this.playPauseImage;
            set
            {
                if (this.playPauseImage != value)
                {
                    this.playPauseImage = value;
                    this.OnPropertyChanged(nameof(this.PlayPauseImage));
                }
            }
        }

        /// <summary>
        /// gets or sets StartTime.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// gets or sets TimerName (not currently used).
        /// </summary>
        public string TimerName { get; set; }

        /// <summary>
        /// gets or sets TimeRemaining for propertychange.
        /// </summary>
        public TimeSpan TimeRemaining
        {
            get => this.timeRemaining;
            set
            {
                if (this.timeRemaining != value)
                {
                    this.timeRemaining = value;
                    this.OnPropertyChanged(nameof(this.TimeRemaining));
                }
            }
        }

        /// <summary>
        /// Gets the StartTimer command.
        /// </summary>
        public ICommand StartTimer => new Command(o => this.StartTimerHandler());

        /// <inheritdoc/>
        public void Dispose()
        {
            // Dispose of unmanaged resources and suppress finalization.
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of the managed resources.
        /// </summary>
        /// <param name="disposing">An indication whether the managed resources are to be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Dispose of the managed resources.
            if (disposing)
            {
                this.timer.Dispose();
            }
        }

        /// <param name="property">used for propety change.</param>
        private void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void StartTimerHandler()
        {
                this.IsRunning = true;
                this.PlayPauseImage = "Assets/stop.png";
                this.EndTime = DateTime.Now + TimeSpan.FromSeconds(int.Parse(this.EntryTime, CultureInfo.InvariantCulture));
                this.TimeRemaining = this.EndTime - DateTime.Now;
                this.timer.Start();
                this.timer.Elapsed += TimerElapsed;
                void TimerElapsed(object sender, ElapsedEventArgs e)
                {
                    this.TimeRemaining = this.EndTime - DateTime.Now;
                    if (this.TimeRemaining <= TimeSpan.Zero)
                    {
                        this.timer.Stop();
                        this.PlayPauseImage = "Assets/play.png";
                        Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Timer Complete", $"Your timer for {this.EntryTime} seconds has completed!", "OK"));
                        System.Diagnostics.Debug.WriteLine("COMPLETE");
                        this.timer.Elapsed -= TimerElapsed;
                    }
                }
        }
    }
}