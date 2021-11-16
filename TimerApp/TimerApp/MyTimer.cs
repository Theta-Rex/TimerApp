// <copyright file="MyTimer.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Timers;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// Enum for LogType for each timer.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Error.
        /// </summary>
        Error,

        /// <summary>
        /// Warning.
        /// </summary>
        Warning,

        /// <summary>
        /// Debug.
        /// </summary>
        Debug,

        /// <summary>
        /// Information.
        /// </summary>
        Information,
    }

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
        private readonly Timer timer = new Timer() { Interval = MyTimer.TimerInterval };

        private CultureInfo culture = CultureInfo.CurrentCulture;

        private string playPauseImage;

        private string selectedLogPicker;

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
            this.LogTypes = new List<string>();

            foreach (string s in Enum.GetNames(typeof(LogType)))
            {
                this.LogTypes.Add(s);
            }

            if (this.culture.Name.Equals("en-US"))
            {
                this.CountdownFinishedText = $"Yo, your timer for {this.EntryTime} has completed!";
            }
            else if (this.culture.Name.Equals("en-CA"))
            {
                this.CountdownFinishedText = $"Your timer for {this.EntryTime} expired, eh";
            }

            this.timer.Elapsed += (s, e) =>
                {
                    this.TimeRemaining = this.EndTime - DateTime.Now;
                    if (this.TimeRemaining <= TimeSpan.Zero)
                    {
                        this.timer.Stop();
                        this.PlayPauseImage = "Assets/play.png";
                        Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Timer Complete", $"{this.CountdownFinishedText}", "OK", "Cancel"));
                    }
                };
        }

        /// <summary>
        /// used for IPropertyNotify.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// gets or sets text for DisplayAlert when countdonw completes.
        /// </summary>
        public string CountdownFinishedText { get; set; }

        /// <summary>
        /// gets or sets EndTime.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// gets or sets EntryTime, which is the amount of time entered by the user.
        /// </summary>
        public string EntryTime { get; set; }

        /// <summary>
        /// gets or sets EntryLog, which is the message the user enters to be logged.
        /// </summary>
        public string EntryLog { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsRunning is true.
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Gets or sets list of LogTypes for picker.
        /// </summary>
        public List<string> LogTypes { get; set; }

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
        /// gets or sets SelectedLogPicker for propertychange.
        /// </summary>
        public string SelectedLogPicker
        {
            get => this.selectedLogPicker;
            set
            {
                if (this.selectedLogPicker != value)
                {
                    this.selectedLogPicker = value;
                    this.OnPropertyChanged(nameof(this.SelectedLogPicker));
                    System.Diagnostics.Debug.WriteLine(this.SelectedLogPicker);
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
        }
    }
}