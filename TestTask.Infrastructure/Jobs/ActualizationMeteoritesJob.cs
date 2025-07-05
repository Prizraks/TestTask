// <copyright file="LoadMeteoritesJob.cs" company="V.Muryn Company">
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
    internal class ActualizationMeteoritesJob : IInvocable, ICancellableInvocable
    {
        private readonly IMeteoriteService meteoriteService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActualizationMeteoritesJob"/> class.
        /// </summary>
        /// <param name="meteoriteService">Meteorite service.</param>
        public ActualizationMeteoritesJob(IMeteoriteService meteoriteService)
        {
            this.meteoriteService = meteoriteService;
        }

        /// <inheritdoc/>
        public CancellationToken CancellationToken { get; set; }

        /// <inheritdoc/>
        public async Task Invoke()
        {
            await this.meteoriteService.ActualizationMeteoritesAsync(this.CancellationToken);
        }
    }
}