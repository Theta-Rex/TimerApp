// <copyright file="MenuItemViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// View model for an item.
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Provides navigation for the view model.
        /// </summary>
        private readonly Navigator navigator;

        /// <summary>
        /// The image that appears in the manu item.
        /// </summary>
        private string image;

        /// <summary>
        /// The text that appears in the menu item.
        /// </summary>
        private string label;

        private Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="image">The image for the menu item.</param>
        /// <param name="label">The label for the menu item.</param>
        public MenuItemViewModel(string image, string label, Navigator navigator, Type type)
        {
            this.image = image;
            this.label = label;
            this.navigator = navigator;
            this.type = type;
        }

        /// <summary>
        /// Gets or sets command that is executed when the item is pressed.
        /// </summary>
        public ICommand Command => new Command(o => this.NavigateHandlerAsync());

        private void NavigateHandlerAsync()
        {
            this.Push(this.type);
            // this.SetRoot(this.type);

            //var page = new NavigationPage(Activator.CreateInstance(this.type) as Page);
            //this.navigator.Navigation.PushAsync(page);

        }

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
    }
}