// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Api
{
    using Coravel;

    using TestTask.Api.Middlewares;
    using TestTask.Infrastructure.Jobs.Configuration;

    /// <summary>
    /// Startup configure.
    /// </summary>
    internal static class StartupConfigure
    {
        /// <summary>
        /// Cors politicy name.
        /// </summary>
        public const string CorsPoliticy = "AllowVueDevServer";

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

        /// <summary>
        /// Add CORS Politicy.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddCorsPoliticy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    CorsPoliticy,
                    policy => policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }
    }
}