// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Infrastructure.Data;
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
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddJobs();
        }
    }
}
