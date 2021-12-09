// <copyright file="MainPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Airey</author>
namespace TimerApp.Views
{
    using TimerApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Main page of the application.
    /// </summary>
    public partial class MainPage : FlyoutPage
    {
        /// <summary>
        /// The view model.
        /// </summary>
        private readonly LandingViewModel landingViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="aboutPage">The 'About' page.</param>
        /// <param name="landingPage">The landing page.</param>
        /// <param name="masterPage">The landing page for the application.</param>
        /// <param name="navigator">Mediates navigation between pages.</param>
        /// <param name="timerPage">The timer page.</param>
        /// <param name="landingViewModel">The landing view model.</param>
        public MainPage(
            AboutPage aboutPage,
            LandingPage landingPage,
            MasterPage masterPage,
            Navigator navigator,
            TimerPage timerPage,
            LandingViewModel landingViewModel)
        {
            // Initialize the object.
            this.Flyout = masterPage;

            // Initialize the IDE managed components.
            this.InitializeComponent();

            // The details pop-over the master only in UWP.  For the other OSs, this is the default.
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            }

            // Provide a view model for the page.
            this.BindingContext = this.landingViewModel = landingViewModel;

            // Set the main landing page for the application.
            this.Detail = new NavigationPage(landingPage);

            // Initialize the navigator to select the proper view based on the view model.
            navigator.Navigation = this.Detail.Navigation;
            navigator.PageMap.Add(typeof(AboutViewModel), aboutPage);
            navigator.PageMap.Add(typeof(TimerViewModel), timerPage);
            navigator.PageMap.Add(typeof(LandingViewModel), landingPage);
        }
    }
}