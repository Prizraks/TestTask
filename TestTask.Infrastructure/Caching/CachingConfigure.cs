// <copyright file="CachingConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Caching
{
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Application;

    /// <summary>
    /// Caching configure.
    /// </summary>
    internal static class CachingConfigure
    {
        /// <summary>
        /// Add caching.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheManager, CacheManager>();
        }
    }
}