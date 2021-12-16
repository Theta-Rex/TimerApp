// <copyright file="TimerViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Microsoft.Extensions.DependencyInjection;
    using TimerApp.Services;
    using Xamarin.Forms;

    /// <summary>
    /// TimerViewModel class.
    /// </summary>
    public class TimerViewModel : BaseViewModel
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        private readonly ITimerService timerService;

        private ObservableCollection<TimerItemViewModel> myTimers;

        /// <summary>
        /// The selected timer.
        /// </summary>
        private TimerItemViewModel selectedTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerViewModel"/> class.
        /// </summary>
        /// <param name="serviceProvider">The DI container.</param>
        /// <param name="timerService">The timerService.</param>
        public TimerViewModel(IServiceProvider serviceProvider, ITimerService timerService)
        {
            // Initialize the object.
            this.serviceProvider = serviceProvider;

            this.timerService = timerService;

            this.MyTimers = new ObservableCollection<TimerItemViewModel>();

            this.GetTimers();
        }

        /// <summary>
        /// Gets or sets a collection of MyTimers.
        /// </summary>
        public ObservableCollection<TimerItemViewModel> MyTimers
        {
            get => this.myTimers;

            set
            {
                if (this.myTimers != value)
                {
                    this.myTimers = value;
                    this.OnPropertyChanged(nameof(this.MyTimers));
                }
            }
        }

        /// <summary>
        /// gets or sets selectedtimer.
        /// </summary>
        public TimerItemViewModel SelectedTimer
        {
            get
            {
                return this.selectedTimer;
            }

            set
            {
                if (this.selectedTimer != value)
                {
                    this.selectedTimer = value;
                }
            }
        }

        /// <summary>
        /// Gets command to add new timer to MyTimers.
        /// </summary>
        public ICommand AddTimer => new Command(o => this.AddTimerHandler());

        /// <summary>
        /// Gets command to Delete timer using button on toolbar.
        /// </summary>
        public ICommand DeleteFromToolbar => new Command(o => this.DeleteTimerHandler());

        /// <summary>
        /// Deletes timers.
        /// </summary>
        public async void DeleteTimerHandler()
        {
            await this.timerService.DeleteTimer(this.SelectedTimer);
            this.GetTimers();
        }

        /// <summary>
        /// Adds timers.
        /// </summary>
        public async void AddTimerHandler()
        {
            var timerItemViewModel = this.serviceProvider.GetRequiredService<TimerItemViewModel>();
            {
                timerItemViewModel.EntryTime = "0";
                timerItemViewModel.SeverityId = 1;
                timerItemViewModel.UserId = 1;
            }

            await this.timerService.AddTimer(timerItemViewModel);
            this.GetTimers();
        }

        /// <summary>
        /// Gets timers from server.
        /// </summary>
        public async void GetTimers()
        {
            this.MyTimers.Clear();
            var timers = await this.timerService.GetTimers();
            foreach (var timerItemViewModel in timers)
            {
                if (timerItemViewModel.SelectedLogPicker == null)
                {
                    timerItemViewModel.SeverityId = 1;
                }

                timerItemViewModel.TimerItemPropertyChanged += this.OnTimerItemPropertyChanged;
                this.MyTimers.Add(timerItemViewModel);
            }
        }

        /// <summary>
        /// Notifies when the TimerItem's property's value has changed.
        /// </summary>
        /// <param name="source">The timerItemViewModel.</param>
        /// <param name="e">Event args.</param>
        public void OnTimerItemPropertyChanged(object source, EventArgs e)
        {
            var timerItemViewModel = (TimerItemViewModel)source;

            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SelectedLogPicker = timerItemViewModel.Severitys[0];
            }

            timerItemViewModel.SeverityId = (int)Enum.Parse(typeof(Severity), timerItemViewModel.SelectedLogPicker);

            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SeverityId = 1;
            }

            this.UpdateTimer(timerItemViewModel);
        }

        /// <summary>
        /// Notifies when the TimerItem's property's value has changed.
        /// </summary>
        /// <param name="timerItemViewModel">The timerItemViewModel.</param>
        public async void UpdateTimer(TimerItemViewModel timerItemViewModel)
        {
            if (timerItemViewModel.EntryTime == string.Empty)
            {
                timerItemViewModel.EntryTime = "0";
            }

            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SelectedLogPicker = timerItemViewModel.Severitys[0];
            }

            timerItemViewModel.SeverityId = (int)Enum.Parse(typeof(Severity), timerItemViewModel.SelectedLogPicker);

            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SeverityId = 1;
            }

            await this.timerService.UpdateTimer(timerItemViewModel);
        }
    }
}