// <copyright file="TimerViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Extensions.DependencyInjection;

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
        /// Initializes a new instance of the <see cref="TimerViewModel"/> class.
        /// </summary>
        /// <param name="serviceProvider">The DI container.</param>
        public TimerViewModel(IServiceProvider serviceProvider)
        {
            // Initialize the object.
            this.serviceProvider = serviceProvider;

            // Create a single timer using DI.
            this.MyTimers.Add(this.serviceProvider.GetRequiredService<TimerItemViewModel>());
            System.Diagnostics.Debug.WriteLine("TIMERVIEWMODEL CONSTRUCTED");
            System.Diagnostics.Debug.WriteLine(this.MyTimers.Count);
        }

        /// <summary>
        /// Gets a collection of MyTimers.
        /// </summary>
        public ObservableCollection<TimerItemViewModel> MyTimers { get; } = new ObservableCollection<TimerItemViewModel>();
    }
}