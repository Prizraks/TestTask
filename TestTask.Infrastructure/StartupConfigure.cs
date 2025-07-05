// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Infrastructure.Data;
    using TestTask.Infrastructure.Data.Repositories;
    using TestTask.Infrastructure.Integrations;
    using TestTask.Infrastructure.Jobs.Configuration;

    /// <summary>
    /// Infrastructure configure.
    /// </summary>
    public static class StartupConfigure
    {
        /// <summary>
        /// Add infrastructure services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase();
            services.AddRepositories();
            services.AddJobs();
            services.AddIntegrationService(configuration);
        }
    }
}