// <copyright file="ITimerService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using TimerApp.ViewModels;

    /// <summary>
    /// ITimerService interface.
    /// </summary>
    public interface ITimerService
    {
        /// <summary>
        /// GetTimers task.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<TimerItemViewModel>> GetTimers();

        /// <summary>
        /// GetTimer task.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The id for the TimerItem.</param>
        Task<TimerItemViewModel> GetTimer(int id);

        /// <summary>
        /// AddTimer task.
        /// </summary>
        /// <param name="timerItemViewModel">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddTimer(TimerItemViewModel timerItemViewModel);

        /// <summary>
        /// DeleteTimer task.
        /// </summary>
        /// <param name="timerItemViewModel">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteTimer(TimerItemViewModel timerItemViewModel);

        /// <summary>
        /// UpdateTimer task.
        /// </summary>
        /// <param name="timerItemViewModel">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateTimer(TimerItemViewModel timerItemViewModel);
    }
}
