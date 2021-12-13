// <copyright file="App.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp
{
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using TimerApp.Services;
    using TimerApp.ViewModels;
    using TimerApp.Views;
    using Xamarin.Forms;

    /// <summary>
    /// App class inherting from Application.
    /// </summary>
    public partial class App : Application
    {
#if RELEASE
        private const string EnvironmentName = "Production";
#elif DEBUG
        private const string EnvironmentName = "Development";
#endif

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

            // Build the configuration.  The configuration files are embedded in this assembly.  This allows us to not have to worry about the
            // differences between the file systems on the different devices or where the 'Content' files might end up.
            var assembly = Assembly.GetExecutingAssembly();
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .AddJsonStream(assembly.GetManifestResourceStream($"{assembly.GetName().Name}.appsettings.json"))
               .AddJsonStream(assembly.GetManifestResourceStream($"{assembly.GetName().Name}.appsettings.{App.EnvironmentName}.json"))
               .Build();

            // Build the Dependency Injection container.
            this.serviceProvider = new ServiceCollection()
                .AddTransient<AboutViewModel>()
                .AddTransient<LandingViewModel>()
                .AddTransient<MasterViewModel>()
                .AddTransient<TimerViewModel>()
                .AddTransient<TimerItemViewModel>()
                .AddTransient<AboutPage>()
                .AddTransient<LandingPage>()
                .AddTransient<MainPage>()
                .AddTransient<MasterPage>()
                .AddTransient<MenuItemViewModel>()
                .AddSingleton<Navigator>()
                .AddTransient<TimerPage>()
                .AddTransient<ITimerService, ApiService>()
                .AddLocalization()
                .AddLogging(loggingBuilder => App.BuildLog(configuration, loggingBuilder))
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

        /// <summary>
        /// Build the logging service.
        /// </summary>
        /// <param name="configuration">The configuration settings.</param>
        /// <param name="loggingBuilder">The log builder.</param>
        private static void BuildLog(IConfiguration configuration, ILoggingBuilder loggingBuilder)
        {
            // Configure the ApplicationInsights logging.  Use the console if no web based telemetry is specified.
            TelemetryOptions telemetryOptions = configuration.GetSection("Telemetry").Get<TelemetryOptions>();
            if (telemetryOptions != null && telemetryOptions.InstrumentationKey != null)
            {
                loggingBuilder.AddApplicationInsights(telemetryOptions.InstrumentationKey);
            }
            else
            {
                loggingBuilder.AddConsole();
            }
        }
    }
}
