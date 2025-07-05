// <copyright file="JobsCronOptions.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Jobs.Configuration
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// CRON configuration for Jobs.
    /// </summary>
    public class JobsCronOptions
    {
        private const string JobsCron = "JobsCron";

        /// <summary>
        /// Initializes a new instance of the <see cref="JobsCronOptions"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public JobsCronOptions(IConfiguration configuration)
        {
            configuration
                .Bind(JobsCron, this);

            if (string.IsNullOrWhiteSpace(this.ActualizationMeteoritesCron))
            {
                throw new InvalidOperationException($"Not find value in {JobsCron} section.");
            }
        }

        /// <summary>
        /// Gets ActualizationMeteorites Cron.
        /// </summary>
        public string ActualizationMeteoritesCron { get; init; }
    }
}