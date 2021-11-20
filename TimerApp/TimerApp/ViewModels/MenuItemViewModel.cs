// <copyright file="MenuItemViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;

    /// <summary>
    /// View model for an item.
    /// </summary>
    public class MenuItemViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The image that appears in the manu item.
        /// </summary>
        private string image;

        /// <summary>
        /// The text that appears in the menu item.
        /// </summary>
        private string label;

        /// <summary>
        /// used for IPropertyNotify.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets command that is executed when the item is pressed.
        /// </summary>
        public ICommand Command { get; set; }

        /// <summary>
        /// Gets or sets command that is executed when the item is pressed.
        /// </summary>
        public object CommandParameter { get; set; }

        /// <summary>
        /// Gets or sets the image on the menu item.
        /// </summary>
        public string Image
        {
            get => this.image;
            set => this.SetProperty(ref this.image, value, nameof(this.Image));
        }

        /// <summary>
        /// Gets or sets the label on the menu item.
        /// </summary>
        public string Label
        {
            get => this.label;
            set => this.SetProperty(ref this.label, value, nameof(this.Label));
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