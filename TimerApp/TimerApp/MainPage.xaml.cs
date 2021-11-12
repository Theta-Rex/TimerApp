// <copyright file="MainPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// MainPage class inheriting from ContentPage.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}
