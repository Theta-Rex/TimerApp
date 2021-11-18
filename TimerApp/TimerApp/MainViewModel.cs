// <copyright file="MainViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// MainViewModel class.
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="serviceProvider">The DI container.</param>
        public MainViewModel(IServiceProvider serviceProvider)
        {
            // Initialize the object.
            this.serviceProvider = serviceProvider;

            // Create a single timer using DI.
            this.MyTimers.Add(serviceProvider.GetRequiredService<MyTimer>());
        }

        /// <summary>
        /// Gets a collection of MyTimers.
        /// </summary>
        public ObservableCollection<MyTimer> MyTimers { get; } = new ObservableCollection<MyTimer>();
    }
}