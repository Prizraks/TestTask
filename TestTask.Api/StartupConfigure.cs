// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Api
{
    using Coravel;
    using Coravel.Scheduling.Schedule.Interfaces;

    using TestTask.Api.Middlewares;
    using TestTask.Infrastructure.Jobs.Configuration;

    /// <summary>
    /// Startup configure.
    /// </summary>
    internal static class StartupConfigure
    {
        /// <summary>
        /// Register scheduler.
        /// </summary>
        /// <param name="builder">Builder.</param>
        /// <param name="configuration">Configuration.</param>
        public static void UseScheduler(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.ApplicationServices
                .UseScheduler(scheduler => JobsConfiguration.ConfigureJobs(scheduler, new JobsCronOptions(configuration)))
                .LogScheduledTaskProgress();
        }

        /// <summary>
        /// Register RequestCancellationMiddleware.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public static void UseRequestCancellationLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestCancellationMiddleware>();
        }
    }
}