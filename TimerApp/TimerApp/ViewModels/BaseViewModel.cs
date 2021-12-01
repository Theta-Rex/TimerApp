// <copyright file="BaseViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// BaseVidewModel class abstracts INotifyPropertyChanged for viewmodels.
    /// </summary>
    public class BaseViewModel : Navigator, INotifyPropertyChanged
    {
        /// <summary>
        /// Required event for INotifyPropertyChanged interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies when a property's value has changed.
        /// </summary>
        /// <param name="property">used for propety change.</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Notifies when a property's value has changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="backingStore">The previous value of the property.</param>
        /// <param name="value">The new value of the property.</param>
        /// <param name="propertyName">The property name.</param>
        protected virtual void SetProperty<T>(ref T backingStore, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                backingStore = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
