// <copyright file="MainPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Airey</author>
namespace TimerApp.UWP
{
    /// <summary>
    /// Main page of the application.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            // Initialize the IDE compoents.
            this.InitializeComponent();

            // Load the application into the devices OS.
            this.LoadApplication(new TimerApp.App());
        }
    }
}
