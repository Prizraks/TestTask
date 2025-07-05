// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application
{
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Application.Meteorite.Services;
    using TestTask.Application.Meteorite.Services.Contracts;

    /// <summary>
    /// Application configure.
    /// </summary>
    public static class StartupConfigure
    {
        /// <summary>
        /// Add application services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMeteoriteService, MeteoriteService>();
        }
    }
}