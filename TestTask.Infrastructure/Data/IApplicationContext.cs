// <copyright file="IApplicationContext.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Interface of application context.
    /// </summary>
    internal interface IApplicationContext
    {
        /// <summary>
        /// Gets meteorities.
        /// </summary>
        public DbSet<Meteorite> Meteorites { get; }
    }
}