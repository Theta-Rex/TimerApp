// <copyright file="App.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using Microsoft.Extensions.DependencyInjection;
    using Xamarin.Forms;

    /// <summary>
    /// App class inherting from Application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The Dependency Injection container.
        /// </summary>
        private readonly ServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            // Initialize the IDE components.
            this.InitializeComponent();

            // Build the Dependency Injection container.
            this.serviceProvider = new ServiceCollection()
                .AddTransient<MainViewModel>()
                .AddTransient<MainPage>()
                .AddTransient<MyTimer>()
                .AddLocalization()
                .AddLogging()
                .BuildServiceProvider();
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
            // This is now the main page.
            this.MainPage = this.serviceProvider.GetRequiredService<MainPage>();

            // Allow the base class to finish starting the app.
            base.OnStart();
        }
    }
}
