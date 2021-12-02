namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections.ObjectModel;
    using Microsoft.Extensions.DependencyInjection;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandingViewModel : BaseViewModel
    {

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly Navigator navigator;

        public LandingViewModel(IServiceProvider serviceProvider, Navigator navigator)
        {
            this.navigator = navigator;
        }

        public ICommand NavigateToTimerPage => new Command(o => this.navigator.SetRoot(typeof(TimerViewModel)));


    }
}
