// <copyright file="StartupConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web
{
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Application.Web.Meteorites;

    /// <summary>
    /// Web application configure.
    /// </summary>
    public static class StartupConfigure
    {
        /// <summary>
        /// Add web app services.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddWebAppServices(this IServiceCollection services)
        {
            services.AddScoped<IMeteoriteWebService, MeteoriteWebService>();
        }
    }
}