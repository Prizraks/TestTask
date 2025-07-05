// <copyright file="JobsConfiguration.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Jobs.Configuration
{
    using Coravel.Scheduling.Schedule.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Job configuration class.
    /// </summary>
    public static class JobsConfiguration
    {
        /// <summary>
        /// Add jobs.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <returns>Changed services.</returns>
        public static IServiceCollection AddJobs(this IServiceCollection services)
        {
            services.AddTransient<ActualizationMeteoritesJob>();

            return services;
        }

        /// <summary>
        /// Configure jobs.
        /// </summary>
        /// <param name="scheduler">Scheduler.</param>
        /// <param name="jobsCronOptions">Jobs cron options.</param>
        public static void ConfigureJobs(IScheduler scheduler, JobsCronOptions jobsCronOptions)
        {
            scheduler
                .Schedule<ActualizationMeteoritesJob>()
                .Cron(jobsCronOptions.ActualizationMeteoritesCron)
                .Zoned(TimeZoneInfo.Local);
        }
    }
}