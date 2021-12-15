// <copyright file="TimerItemEventArgs.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System;

    /// <summary>
    /// TimerItemEventArgs class.
    /// </summary>
    public class TimerItemEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the TimerItemViewModel for event handler.
        /// </summary>
        public TimerItemViewModel TimerItemViewModel { get; set; }
    }
}