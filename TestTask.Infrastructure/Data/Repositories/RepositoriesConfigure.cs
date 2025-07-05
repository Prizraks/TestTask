// <copyright file="RepositoriesConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Application.Meteorite;
    using TestTask.Infrastructure.Data.Repositories.Meteorite;

    /// <summary>
    /// Repositories configure.
    /// </summary>
    internal static class RepositoriesConfigure
    {
        /// <summary>
        /// Add repositories.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<BaseRepository>();
            services.AddScoped<IMeteoriteRepository, MeteoriteRepository>();
        }
    }
}