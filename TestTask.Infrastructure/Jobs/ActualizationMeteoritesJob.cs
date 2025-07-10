// <copyright file="ActualizationMeteoritesJob.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Jobs
{
    using System.Threading;
    using System.Threading.Tasks;

    using Coravel.Invocable;

    using TestTask.Application.Meteorite.Services.Contracts;

    /// <summary>
    /// Actualization meteorites job.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ActualizationMeteoritesJob"/> class.
    /// </remarks>
    /// <param name="meteoriteService">Meteorite service.</param>
    internal class ActualizationMeteoritesJob(IMeteoriteService meteoriteService) : IInvocable, ICancellableInvocable
    {
        private readonly IMeteoriteService meteoriteService = meteoriteService;

        /// <inheritdoc/>
        public CancellationToken CancellationToken { get; set; }

        /// <inheritdoc/>
        public async Task Invoke()
        {
            await this.meteoriteService.ActualizationMeteoritesAsync(this.CancellationToken);
        }
    }
}