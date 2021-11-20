// <copyright file="MasterPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.Views
{
    using TimerApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// The Master Page.
    /// </summary>
    public partial class MasterPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterPage"/> class.
        /// </summary>
        /// <param name="masterViewModel">The view model for the master page.</param>
        public MasterPage(MasterViewModel masterViewModel)
        {
            // Initialize the object.
            this.BindingContext = masterViewModel;

            // Initialize the IDE managed components.
            this.InitializeComponent();
        }
    }
}