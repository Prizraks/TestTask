// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Application configure.
    /// </summary>
    public static class StartupConfigure
    {
        /// <summary>
        /// Add infrastructure services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddJobs();
        }
    }
}
