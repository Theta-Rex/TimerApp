// <copyright file="TimerItem.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    /// <summary>
    /// Model for TimerItem.
    /// </summary>
    public class TimerItem
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets EntryTime.
        /// </summary>
        public int EntryTime { get; set; }

        /// <summary>
        /// Gets or sets SeverityId.
        /// </summary>
        public int SeverityId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
