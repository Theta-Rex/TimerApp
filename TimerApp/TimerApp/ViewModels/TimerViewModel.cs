// <copyright file="TimerViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
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

        /// <summary>
        /// The repository for all timer resources.
        /// </summary>
        private readonly ITimerService timerService;

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

            // We want to avoid running long tasks in the constructors.  If every class in a large project took a long time to initialize, then it
            // would impact the startup time.  Initialize the observable collection of timers from the web service in the background.
            _ = Task.Run(async () =>
            {
                var timers = await this.timerService.GetTimers();
                foreach (var timerItem in timers)
                {
                    // This creates a fully realized view model using DI for the observable collection.  We attach an event handler to it to be
                    // informed of updates triggered by the user.
                    TimerItemViewModel timerItemViewModel = this.serviceProvider.GetRequiredService<TimerItemViewModel>();
                    timerItemViewModel.Id = timerItem.Id;
                    timerItemViewModel.UserId = timerItem.UserId;
                    timerItemViewModel.EntryTime = Convert.ToString(timerItem.EntryTime);
                    timerItemViewModel.SeverityId = timerItem.SeverityId;
                    timerItemViewModel.TimerItemPropertyChanged += this.OnTimerItemPropertyChanged;
                    this.Timers.Add(timerItemViewModel);
                }
            });
        }

        /// <summary>
        /// Gets a collection of <see cref="TimerItemViewModel"/> items.
        /// </summary>
        public ObservableCollection<TimerItemViewModel> Timers { get; } = new ObservableCollection<TimerItemViewModel>();

        /// <summary>
        /// Gets or sets currently selected timer.
        /// </summary>
        public TimerItemViewModel SelectedTimer { get; set; }

        /// <summary>
        /// Gets command to Delete timer using button on toolbar.
        /// </summary>
        public ICommand Delete => new Command(o => this.DeleteTimerHandler());

        /// <summary>
        /// Deletes timers.
        /// </summary>
        public async void DeleteTimerHandler()
        {
            // Create a model based on the view model and send it to the web service to be deleted.
            await this.timerService.DeleteTimer(
                new TimerItem
                {
                    Id = this.SelectedTimer.Id,
                    EntryTime = Convert.ToInt32(this.SelectedTimer.EntryTime),
                    SeverityId = this.SelectedTimer.SeverityId,
                    UserId = this.SelectedTimer.UserId,
                });

            // If you can avoid a round trip to the web service by doing something locally, then do it locally.
            this.SelectedTimer.TimerItemPropertyChanged -= this.OnTimerItemPropertyChanged;
            this.Timers.Remove(this.SelectedTimer);
        }

        /// <summary>
        /// Notifies when the TimerItem's property's value has changed.
        /// </summary>
        /// <param name="source">The timerItemViewModel.</param>
        /// <param name="e">Event args.</param>
        public async void OnTimerItemPropertyChanged(object source, EventArgs e)
        {
            // Extract the specific view model that generated the event from the generic argument.
            var timerItemViewModel = source as TimerItemViewModel;
            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SelectedLogPicker = timerItemViewModel.Severitys[0];
            }

            timerItemViewModel.SeverityId = (int)Enum.Parse(typeof(Severity), timerItemViewModel.SelectedLogPicker);
            if (timerItemViewModel.SelectedLogPicker == null)
            {
                timerItemViewModel.SeverityId = 1;
            }

            await this.timerService.UpdateTimer(
                new TimerItem
                {
                    Id = timerItemViewModel.Id,
                    EntryTime = Convert.ToInt32(timerItemViewModel.EntryTime),
                    SeverityId = timerItemViewModel.SeverityId,
                    UserId = timerItemViewModel.UserId,
                });
        }
    }
}