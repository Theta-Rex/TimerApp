// <copyright file="MainViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>

namespace TimerApp
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// MainViewModel class.
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.MyTimers = new ObservableCollection<MyTimer>();
            this.MyTimers.Add(new MyTimer("Timer 1", "0"));
            this.MyTimers.Add(new MyTimer("Timer 2", "0"));
            this.MyTimers.Add(new MyTimer("Timer 3", "0"));
        }

        /// <summary>
        /// Gets or sets an Observable Collection of type MyTimers.
        /// </summary>
        public ObservableCollection<MyTimer> MyTimers { get; set; }
    }
}