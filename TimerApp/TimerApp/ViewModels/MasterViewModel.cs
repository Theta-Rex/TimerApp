// <copyright file="MasterViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Airey</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Microsoft.Extensions.Localization;

    /// <summary>
    /// Information about the application.
    /// </summary>
    public class MasterViewModel : INotifyPropertyChanged
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
        /// A value indicating whether the master page is presented or not.
        /// </summary>
        private bool isPresented;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class.
        /// </summary>
        /// <param name="navigator">Provides navigation for the view model.</param>
        /// <param name="stringLocalizer">The string localizer.</param>
        public MasterViewModel(Navigator navigator, IStringLocalizer<MasterViewModel> stringLocalizer)
        {
            // Initialize the object.
            this.navigator = navigator;
            this.stringLocalizer = stringLocalizer;

            // Localize the object.
            this.Exit = this.stringLocalizer["ExitLabel"];
            this.Retry = this.stringLocalizer["RetryLabel"];
            this.ServiceNotRunning = this.stringLocalizer["ServiceNotRunningMessage"];
        }

        /// <summary>
        /// used for IPropertyNotify.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the text for the Exit button.
        /// </summary>
        public string Exit { get; }

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
        /// Gets the text for the Retry button.
        /// </summary>
        public string Retry { get; }

        /// <summary>
        /// Gets the text for message that the service isn't running.
        /// </summary>
        public string ServiceNotRunning { get; }

        /// <summary>
        /// Handles a change to a property.
        /// </summary>
        /// <param name="property">The name of the property that has changed.</param>
        private void OnPropertyChanged(string property)
        {
            // Make sure the property change handler is in place before invoking it.
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

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