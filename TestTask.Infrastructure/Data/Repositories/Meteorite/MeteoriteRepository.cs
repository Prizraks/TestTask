// <copyright file="MeteoriteRepository.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Repositories.Meteorite
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TestTask.Application.Meteorite;
    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Meteorite repository.
    /// </summary>
    internal class MeteoriteRepository : IMeteoriteRepository
    {
        private readonly BaseRepository baseRepository;
        private readonly IApplicationContext applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeteoriteRepository"/> class.
        /// </summary>
        /// <param name="baseRepository">Base repository.</param>
        /// <param name="applicationContext">Application context.</param>
        public MeteoriteRepository(
            BaseRepository baseRepository,
            IApplicationContext applicationContext)
        {
            this.baseRepository = baseRepository;
            this.applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token)
        {
            await this.baseRepository.CreateRangeAndSaveAsync(meteorites, token);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<Meteorite>> GetAll(CancellationToken token)
        {
            return (await this.applicationContext.Meteorites
                .ToListAsync(token))
                .AsReadOnly();
        }

        /// <inheritdoc/>
        public async Task RemoveRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token)
        {
            await this.baseRepository.DeleteRangeAsync(meteorites, token);
        }

        /// <inheritdoc/>
        public async Task UpdateRangeAsync(IEnumerable<Meteorite> meteorites, CancellationToken token)
        {
            await this.baseRepository.UpdateRangeAndSaveAsync(meteorites, token);
        }
    }
}