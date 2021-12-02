// <copyright file="MenuItemViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// View model for an item.
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The type corresponding to the ViewModel that's passed to PageMap as a key.
        /// </summary>
        private readonly Type type;

        /// <summary>
        /// Provides navigation for the view model.
        /// </summary>
        private Navigator navigator;

        /// <summary>
        /// The image that appears in the manu item.
        /// </summary>
        private string image;

        /// <summary>
        /// The text that appears in the menu item.
        /// </summary>
        private string label;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="image">The image for the menu item.</param>
        /// <param name="label">The label for the menu item.</param>
        /// <param name="navigator">Mediates navigation between pages.</param>
        /// <param name="type">The type corresponding to the ViewModel that's passed to PageMap as a key.</param>
        public MenuItemViewModel(string image, string label, Navigator navigator, Type type)
        {
            this.image = image;
            this.label = label;
            this.navigator = navigator;
            this.type = type;
        }

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
        /// Gets the commend whene on the menu item.
        /// </summary>
        public ICommand Command => new Command(o => this.navigator.Push(this.type));
    }
}