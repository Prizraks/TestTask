// <copyright file="IApplicationContext.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Interface of application context.
    /// </summary>
    internal interface IApplicationContext
    {
        /// <summary>
        /// Gets meteorities.
        /// </summary>
        DbSet<Meteorite> Meteorites { get; }

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task SaveAsync(CancellationToken token);

        /// <summary>
        /// Gets a record of an entity that allows changes to be tracked and operations to be performed on the entity.
        /// </summary>
        /// <typeparam name="TEntity">Type entity.</typeparam>
        /// <param name="entity">Entity.</param>
        /// <returns>Entity row.</returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Creates a set that can be used to query and save entities.
        /// </summary>
        /// <typeparam name="TEntity">Type entity.</typeparam>
        /// <returns>Set for the provided entity type</returns>
        DbSet<TEntity> Set<TEntity> ()
            where TEntity : class;
    }
}