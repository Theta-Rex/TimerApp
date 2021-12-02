namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections.ObjectModel;
    using Microsoft.Extensions.DependencyInjection;

    public class LandingViewModel : BaseViewModel
    {

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        public LandingViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
