// <copyright file="TelemetryOptions.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Donald Roy Airey</author>
namespace TimerApp
{
    /// <summary>
    /// The options for telemetry and instrumentation.
    /// </summary>
    public class TelemetryOptions
    {
        /// <summary>
        /// Gets or sets instrumentation key for Application Insights.
        /// </summary>
        public string InstrumentationKey { get; set; }
    }
}