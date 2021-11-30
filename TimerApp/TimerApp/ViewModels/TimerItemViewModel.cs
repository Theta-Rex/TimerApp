// <copyright file="TimerItemViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Timers;
    using System.Windows.Input;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Xamarin.Forms;

    /// <summary>
    /// MyTimer class creates an object for each Timer.
    /// </summary>
    public class TimerItemViewModel : BaseViewModel, IDisposable
    {
        /// <summary>
        ///  The update interval of the timer.
        /// </summary>
        private const int TimerInterval = 1000;

        /// <summary>
        /// System timer.
        /// </summary>
        private readonly Timer timer = new Timer() { Interval = TimerItemViewModel.TimerInterval };

        private readonly ILogger logger;

        private readonly IStringLocalizer stringLocalizer;

        private string playPauseImage;

        private string selectedLogPicker;

        /// <summary>
        /// Calculates time remaining which is bound to the label.
        /// </summary>
        private TimeSpan timeRemaining;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerItemViewModel"/> class.
        /// </summary>
        /// <param name="logger">The log device.</param>
        /// <param name="stringLocalizer">Provides localized (internationalized) strings.</param>
        public TimerItemViewModel(ILogger<TimerItemViewModel> logger, IStringLocalizer<TimerItemViewModel> stringLocalizer)
        {
            // Initialize the object.
            this.logger = logger;
            this.stringLocalizer = stringLocalizer;
            this.PlayPauseImage = "Assets/play.png";
            this.Severitys = new List<string>();

            foreach (string s in Enum.GetNames(typeof(Severity)))
            {
                this.Severitys.Add(s);
            }
            var result = false;
            this.timer.Elapsed += (s, e) =>
                {
                    this.TimeRemaining = this.EndTime - DateTime.Now;
                    if (this.TimeRemaining <= TimeSpan.Zero)
                    {
                        this.timer.Stop();
                        this.PlayPauseImage = "Assets/play.png";
                        this.logger.LogError(this.stringLocalizer["TimerExpired"]);
                        //this.DisplayAlert();
                        Device.BeginInvokeOnMainThread(
                             () => this.DisplayAlert());
                        //     App.Current.MainPage.DisplayAlert(
                        //        this.stringLocalizer["Title"],
                        //        this.stringLocalizer["TimerExpired"],
                        //        this.stringLocalizer["Retry"],
                        //        this.stringLocalizer["Cancel"]));
                        //if (result)
                        //{
                        //    System.Diagnostics.Debug.WriteLine("Retry");
                        //}
                        //else
                        //{
                        //    System.Diagnostics.Debug.WriteLine("Cancel");
                        //}
                    }
                };
        }

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
        /// Gets or sets list of Severitys for picker.
        /// </summary>
        public List<string> Severitys { get; set; }

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

        private async void DisplayAlert()
        {
            var response = await App.Current.MainPage.DisplayAlert(this.stringLocalizer["Title"], this.stringLocalizer["TimerExpired"], this.stringLocalizer["Retry"], this.stringLocalizer["Cancel"]);
            if (response)
            {
                System.Diagnostics.Debug.WriteLine("Retry");
                this.StartTimerHandler();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Cancel");
            }
        }
    }
}