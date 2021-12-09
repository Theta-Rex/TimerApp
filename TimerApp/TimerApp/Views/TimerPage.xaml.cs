// <copyright file="TimerPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Airey</author>
namespace TimerApp.Views
{
    using TimerApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Allows the user to set and edit timers.
    /// </summary>
    public partial class TimerPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerPage"/> class.
        /// </summary>
        /// <param name="timerViewModel">The timer view model.</param>
        public TimerPage(TimerViewModel timerViewModel)
        {
            // Initialize the object.
            this.InitializeComponent();
            this.BindingContext = timerViewModel;
        }
    }
}