// <copyright file="LoadMeteoritesJob.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Jobs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Coravel.Invocable;

    /// <summary>
    /// Load meteorites job.
    /// </summary>
    internal class LoadMeteoritesJob : IInvocable, ICancellableInvocable
    {
        /// <inheritdoc/>
        public CancellationToken CancellationToken { get; set; }

        /// <inheritdoc/>
        public Task Invoke()
        {
            throw new NotImplementedException();
        }
    }
}