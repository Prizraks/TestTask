// <copyright file="BaseRepository.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    internal class BaseRepository
    {
        private readonly IApplicationContext applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public BaseRepository(IApplicationContext context)
        {
            this.applicationContext = context;
        }

        /// <summary>
        /// Create entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken token)
            where TEntity : class
        {
            this.CheckAdd(entity);
            this.applicationContext.Set<TEntity>().Add(entity);
            await this.SaveChangesAsync(token);
            return entity;
        }

        /// <summary>
        /// Create entities.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entities">Entities.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task CreateRangeAndSaveAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
            where TEntity : class
        {
            if (!(entities ?? []).Any())
            {
                return;
            }

            foreach (var entity in entities)
            {
                this.CheckAdd(entity);
            }

            await this.applicationContext.Set<TEntity>().AddRangeAsync(entities, token);
            await this.SaveChangesAsync(token);
        }

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity, CancellationToken token)
            where TEntity : class
        {
            this.CheckUpdate(entity);

            await this.SaveChangesAsync(token);

            return entity;
        }

        /// <summary>
        /// Update entities.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entities">Entities.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task UpdateRangeAndSaveAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
            where TEntity : class
        {
            if (!(entities ?? []).Any())
            {
                return;
            }

            foreach (var entity in entities)
            {
                this.CheckUpdate(entity);
            }

            this.applicationContext.Set<TEntity>().UpdateRange(entities);
            await this.SaveChangesAsync(token);
        }

        /// <summary>
        /// Delete entity by id.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="id">Id.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> DeleteAsync<TEntity>(object id, CancellationToken token)
            where TEntity : class
        {
            var entity = await this.applicationContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            this.applicationContext.Set<TEntity>().Remove(entity);

            await this.SaveChangesAsync(token);
            return true;
        }

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task DeleteAsync<TEntity>(TEntity entity, CancellationToken token)
            where TEntity : class
        {
            this.CheckRemove(entity);
            this.applicationContext.Set<TEntity>().Remove(entity);
            await this.SaveChangesAsync(token);
        }

        /// <summary>
        /// Delete entities.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entities">Entities.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task DeleteRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
            where TEntity : class
        {
            if (!(entities ?? []).Any())
            {
                return;
            }

            foreach (var entity in entities)
            {
                this.CheckRemove(entity);
            }

            this.applicationContext.Set<TEntity>().RemoveRange(entities);
            await this.SaveChangesAsync(token);
        }

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task SaveChangesAsync(CancellationToken token)
        {
            await this.applicationContext.SaveAsync(token);
        }

        private void CheckAdd<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entityState = this.applicationContext.Entry(entity).State;
            if (entityState != EntityState.Detached)
            {
                throw new InvalidOperationException($"Entity cannot be added because it is in the state {entityState}");
            }
        }

        private void CheckUpdate<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entityState = this.applicationContext.Entry(entity).State;
            if (entityState != EntityState.Modified && entityState != EntityState.Unchanged)
            {
                throw new InvalidOperationException($"Entity cannot be updated because it is in the state {entityState}");
            }
        }

        private void CheckRemove<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entityState = this.applicationContext.Entry(entity).State;
            if (entityState != EntityState.Modified && entityState != EntityState.Unchanged)
            {
                throw new InvalidOperationException($"Entity cannot be removed because it is in the state {entityState}");
            }
        }
    }
}