// <copyright file="ApplicationContextConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Database context configure.
    /// </summary>
    internal static class ApplicationContextConfigure
    {
        /// <summary>
        /// Add database.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<IApplicationContext, ApplicationContext>();
        }
    }
}