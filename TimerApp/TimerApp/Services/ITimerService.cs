// <copyright file="ITimerService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimerApp.Domain;

    /// <summary>
    /// ITimerService interface.
    /// </summary>
    public interface ITimerService
    {
        /// <summary>
        /// GetTimers task.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<TimerItem>> GetTimers();

        /// <summary>
        /// GetTimer task.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="id">The id for the TimerItem.</param>
        Task<TimerItem> GetTimer(int id);

        /// <summary>
        /// AddTimer task.
        /// </summary>
        /// <param name="timerItem">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TimerItem> AddTimer(TimerItem timerItem);

        /// <summary>
        /// DeleteTimer task.
        /// </summary>
        /// <param name="timerItem">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteTimer(TimerItem timerItem);

        /// <summary>
        /// UpdateTimer task.
        /// </summary>
        /// <param name="timerItem">The timerItemViewModel.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateTimer(TimerItem timerItem);
    }
}
