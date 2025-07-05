// <copyright file="IMeteoriteRepository.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Meteorite repository.
    /// </summary>
    public interface IMeteoriteRepository
    {
        /// <summary>
        /// Get all Meteorities.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Meteorities.</returns>
        Task<IReadOnlyCollection<Meteorite>> GetAll(CancellationToken token);

        /// <summary>
        /// Add list meteorites.
        /// </summary>
        /// <param name="meteorites">Meteorites.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task AddRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token);

        /// <summary>
        /// Update list meteorites.
        /// </summary>
        /// <param name="meteorites">Meteorites.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task UpdateRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token);

        /// <summary>
        /// Remove list meteorites.
        /// </summary>
        /// <param name="meteorites">Meteorites.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task RemoveRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token);
    }
}