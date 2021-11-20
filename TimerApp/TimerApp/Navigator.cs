﻿// <copyright file="Navigator.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// Implements the translation of navigation operations from the view models to equivalent operations on the views.
    /// </summary>
    /// <remarks>
    /// The view models are constructed such that they don't have any knowledge of their implelentation as a view.  For this reason, it's impossible
    /// for a view model to handle a command like 'Navigate to a scenario'.  To accomplish this, we map the view model type to the requested page
    /// type.
    /// </remarks>
    public class Navigator
    {
        /// <summary>
        /// Gets or sets the <see cref="INavigation"/> interface.
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Gets the maps of the view model to the view that implements it.
        /// </summary>
        public Dictionary<Type, Page> PageMap { get; } = new Dictionary<Type, Page>();

        /// <summary>
        /// Pushes the current page and navigates to a new one.
        /// </summary>
        /// <param name="type">The type of the view model to which to navigate.</param>
        public void Push(Type type)
        {
            // Translate the page type to a page instance and navigate to that requested page.
            Device.BeginInvokeOnMainThread(() => _ = this.Navigation.PushAsync(this.PageMap[type]).ConfigureAwait(true));
        }

        /// <summary>
        /// Sets the root of the navigator to the given view model.
        /// </summary>
        /// <param name="type">The type of the view model to which to navigate.</param>
        public void SetRoot(Type type)
        {
            // If they're different, then replace the root page with the new root.
            var oldPage = this.Navigation.NavigationStack[0];
            var newPage = this.PageMap[type];
            if (oldPage != newPage)
            {
                Device.BeginInvokeOnMainThread(() => this.Navigation.InsertPageBefore(newPage, oldPage));
            }

            // In all cases, pop the views off the stack until we get to the root.
            Device.BeginInvokeOnMainThread(() => _ = this.PopToRootAsync());
        }

        /// <summary>
        /// Pop the navigation stack back to the root.
        /// </summary>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
        private async Task PopToRootAsync()
        {
            await this.Navigation.PopToRootAsync().ConfigureAwait(true);
        }
    }
}