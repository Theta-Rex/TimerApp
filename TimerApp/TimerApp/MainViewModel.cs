// <copyright file="MainViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

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
            this.MyTimers.Add(new MyTimer("Timer 1", "0"));
            this.MyTimers.Add(new MyTimer("Timer 2", "0"));
            this.MyTimers.Add(new MyTimer("Timer 3", "0"));
        }

        /// <summary>
        /// Gets a collection of MyTimers.
        /// </summary>
        public ObservableCollection<MyTimer> MyTimers { get; } = new ObservableCollection<MyTimer>();

        //private IServiceProvider CreateServiceProvider()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    services.AddSingleton<IMyTimerService>();
        //}
    }

    public class MyTimerService : IMyTimerService
    {

        public Task<MyTimer> GetTimer(MyTimer mytimer)
        {
            throw new NotImplementedException();
        }

        public void AddTimer(MyTimer mytimer)
        {

        }
    }

    public interface IMyTimerService
    {
        Task<MyTimer> GetTimer(MyTimer mytimer);
    }
}