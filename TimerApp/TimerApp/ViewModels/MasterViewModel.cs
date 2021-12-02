// <copyright file="MasterViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Airey</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Localization;
    using TimerApp.Views;

    /// <summary>
    /// Information about the application.
    /// </summary>
    public class MasterViewModel : BaseViewModel
    {
        /// <summary>
        /// Provides navigation for the view model.
        /// </summary>
        private readonly Navigator navigator;

        /// <summary>
        /// The string localizer.
        /// </summary>
        private readonly IStringLocalizer<MasterViewModel> stringLocalizer;

        /// <summary>
        /// The service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// A value indicating whether the master page is presented or not.
        /// </summary>
        private bool isPresented;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class.
        /// </summary>
        /// <param name="navigator">Provides navigation for the view model.</param>
        /// <param name="stringLocalizer">The string localizer.</param>
        /// <param name="serviceProvider">The DI container.</param>
        public MasterViewModel(Navigator navigator, IStringLocalizer<MasterViewModel> stringLocalizer, IServiceProvider serviceProvider)
        {
            // Initialize the object.
            this.navigator = navigator;
            this.stringLocalizer = stringLocalizer;
            this.serviceProvider = serviceProvider;

            // this.MenuItems.Add(this.serviceProvider.GetRequiredService<MenuItemViewModel>());
            this.MenuItems.Add(new MenuItemViewModel("assets/timerlogo.png", "Timer Page", navigator, typeof(TimerViewModel)));
            this.MenuItems.Add(new MenuItemViewModel("assets/about.png", "About Page", navigator, typeof(AboutViewModel)));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the master page is presented or not.
        /// </summary>
        public bool IsPresented
        {
            get => this.isPresented;

            set
            {
                if (this.isPresented != value)
                {
                    this.isPresented = value;
                    this.OnPropertyChanged(nameof(this.IsPresented));
                }
            }
        }

        /// <summary>
        /// Gets the scenarios in the list view.
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; } = new ObservableCollection<MenuItemViewModel>();

        /// <summary>
        /// Sets the root of the master page.
        /// </summary>
        /// <param name="type">The page type that is to become the new root.</param>
        private void SetRoot(Type type)
        {
            // Set the new root for the application.
            this.navigator.SetRoot(type);

            // Close the master page.
            this.IsPresented = false;
        }
    }
}