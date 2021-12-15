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
    /// MainViewModel class.
    /// </summary>
    public class TimerViewModel : BaseViewModel
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        private ITimerService timerService;

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

                    // System.Diagnostics.Debug.WriteLine(this.SelectedTimer.Id);
                    // this.MyTimers.Remove(this.SelectedTimer);
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
            // MyTimers.Add(this.serviceProvider.GetRequiredService<TimerItemViewModel>());
            var timerItemViewModel = this.serviceProvider.GetRequiredService<TimerItemViewModel>();
            {
                timerItemViewModel.EntryTime = "0";
                timerItemViewModel.SeverityId = 1;
                timerItemViewModel.UserId = 1;
            };
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
            foreach (var timer in timers)
            {
                timer.myTimers.Add(timer);
                this.MyTimers.Add(timer);
                //System.Diagnostics.Debug.WriteLine(timer.Id);
            }
        }

        public async void LoadUpdateTimer(int id)
        {
            if (this.timerService == null)
            {
                System.Diagnostics.Debug.WriteLine("Null");
            }
            else
            {
                var timer = await this.timerService.GetTimer(id);
                await this.timerService.UpdateTimer(timer);
            }
        }
    }
}