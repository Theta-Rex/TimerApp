// <copyright file="App.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// App class inherting from Application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            this.MainPage = new MainPage();
        }

        /// <summary>
        /// OnStart.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// OnSleep.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// OnResume.
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
