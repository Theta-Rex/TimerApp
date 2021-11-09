// <copyright file="MyTimer.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Timers;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// MyTimer class creates an object for each Timer.
    /// </summary>
    public class MyTimer : INotifyPropertyChanged
    {
        /// <summary>
        /// calculates time remaining which is bound to the label.
        /// </summary>
        private TimeSpan timeRemaining;

        /// <summary>
        /// System timer.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimer"/> class.
        /// </summary>
        /// <param name="timername">name of timer.</param>
        /// <param name="entrytime">gets entrytime from user.</param>
        public MyTimer(string timername, string entrytime)
        {
            this.TimerName = timername;
            this.EntryTime = entrytime;
        }

        /// <summary>
        /// used for IPropertyNotify.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// gets or sets TimerName (not currently used).
        /// </summary>
        public string TimerName { get; set; }

        /// <summary>
        /// gets or sets EntryTime, which is the amount of time entered by the user.
        /// </summary>
        public string EntryTime { get; set; }

        /// <summary>
        /// gets or sets StartTime.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// gets or sets EndTime.
        /// </summary>
        public DateTime EndTime { get; set; }

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
        /// Gets StartTimerCommand.
        /// </summary>
        public ICommand StartTimerCommand => new Command(this.StartTimer);

        /// <param name="property">used for propety change.</param>
        private void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void StartTimer(object o)
        {
            this.StartTime = DateTime.Now;
            TimeSpan t = TimeSpan.FromSeconds(int.Parse(this.EntryTime));
            this.EndTime = this.StartTime + t;

            this.SystemTimer();
        }

        private void SystemTimer()
        {
            this.timer = new System.Timers.Timer();
            this.timer.Interval = 100;
            this.timer.Elapsed += OnTimedEvent;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
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