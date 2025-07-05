// <copyright file="IMeteoriteService.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite.Services.Contracts
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface meteorite service.
    /// </summary>
    public interface IMeteoriteService
    {
        /// <summary>
        /// Actualization meteorites.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task ActualizationMeteoritesAsync(CancellationToken token);
    }
}