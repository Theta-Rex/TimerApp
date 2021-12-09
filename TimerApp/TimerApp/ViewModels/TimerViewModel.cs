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

        /// <summary>
        /// The selected timer.
        /// </summary>
        private TimerItemViewModel selectedTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerViewModel"/> class.
        /// </summary>
        /// <param name="serviceProvider">The DI container.</param>
        public TimerViewModel(IServiceProvider serviceProvider)
        {
            // Initialize the object.
            this.serviceProvider = serviceProvider;

            // Create a single timer using DI.
            this.MyTimers.Add(this.serviceProvider.GetRequiredService<TimerItemViewModel>());
        }

        /// <summary>
        /// Gets a collection of MyTimers.
        /// </summary>
        public ObservableCollection<TimerItemViewModel> MyTimers { get; } = new ObservableCollection<TimerItemViewModel>();

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

                    // this.MyTimers.Remove(this.SelectedTimer);
                }
            }
        }

        /// <summary>
        /// Gets command to add new timer to MyTimers.
        /// </summary>
        public ICommand AddTimer => new Command(o => this.MyTimers.Add(this.serviceProvider.GetRequiredService<TimerItemViewModel>()));

        /// <summary>
        /// Gets command to Delete timer.
        /// </summary>
        public ICommand DeleteTimer => new Command(o => this.DeleteTimerHandler());

        /// <summary>
        /// Gets command to Delete timer using button on toolbar.
        /// </summary>
        public ICommand DeleteFromToolbar => new Command(o => this.MyTimers.Remove(this.SelectedTimer));

        private void DeleteTimerHandler()
        {
            //// TimerItemViewModel t = this.serviceProvider.GetRequiredService<TimerItemViewModel>();
            // this.MyTimers.Remove(this.SelectedTimer);
        }
    }
}