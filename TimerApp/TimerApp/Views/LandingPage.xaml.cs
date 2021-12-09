// <copyright file="LandingPage.xaml.cs" company="Theta Rex, Inc.">
// Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>

namespace TimerApp.Views
{
    using TimerApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// LandingPage class inheriting from ContentPage.
    /// </summary>
    public partial class LandingPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LandingPage"/> class.
        /// </summary>
        /// <param name="landingViewModel">landing viewmodel.</param>
        public LandingPage(LandingViewModel landingViewModel)
        {
            this.InitializeComponent();
            this.BindingContext = landingViewModel;
        }
    }
}