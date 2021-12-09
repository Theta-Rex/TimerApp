// <copyright file="LandingViewModel.cs" company="Theta Rex, Inc.">
// Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// The view model for the Landing page.
    /// </summary>
    public class LandingViewModel : BaseViewModel
    {
        /// <summary>
        /// The navigator.
        /// </summary>
        private readonly Navigator navigator;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandingViewModel"/> class.
        /// </summary>
        /// <param name="navigator">Provides navigation.</param>
        public LandingViewModel(Navigator navigator)
        {
            this.navigator = navigator;
            this.ButtonText = "Go to Timers";
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// Gets the NavigateToTimerPage command.
        /// </summary>
        public ICommand NavigateToTimerPage => new Command(o => this.navigator.SetRoot(typeof(TimerViewModel)));
    }
}
