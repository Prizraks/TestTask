// <copyright file="IGitHubApi.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.GitHub
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestTask.Application.GitHub.Models;

    /// <summary>
    /// GitHub api.
    /// </summary>
    public interface IGitHubApi
    {
        /// <summary>
        /// Gets meteorites from GitHub.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task<IEnumerable<MeteoriteApiModel>> GetMeteoritesAsync(CancellationToken token);
    }
}