// <copyright file="IApiService.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using TimerApp.ViewModels;

    public interface ITimerService
    {
        Task<IEnumerable<TimerItemViewModel>> GetTimers();
        Task<TimerItemViewModel> GetTimer(int id);
    }
}
