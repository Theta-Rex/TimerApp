// <copyright file="AboutViewModel.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp.ViewModels
{
    using Microsoft.Extensions.Localization;

    /// <summary>
    /// Information about the application.
    /// </summary>
    public class AboutViewModel
    {
        /// <summary>
        /// The string localizer.
        /// </summary>
        private readonly IStringLocalizer localizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        /// <param name="localizer">The string localizer.</param>
        public AboutViewModel(IStringLocalizer<AboutViewModel> localizer)
        {
            // Initialize the object.
            this.localizer = localizer;
            this.Description = this.localizer["Description"];
            this.Name = "Timer";
            this.Version = "1.0";
            this.Title = this.localizer["Title"];
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the title of the view.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public string Version { get; }
    }
}