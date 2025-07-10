// <copyright file="MeteoriteService.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using TestTask.Application.GitHub;
    using TestTask.Application.Meteorite.Comparers;
    using TestTask.Application.Meteorite.Services.Contracts;
    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Meteorite service.
    /// </summary>
    internal class MeteoriteService : IMeteoriteService
    {
        private readonly IGitHubApi gitHubApi;
        private readonly IMeteoriteRepository meteoriteRepository;
        private readonly ITransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeteoriteService"/> class.
        /// </summary>
        /// <param name="gitHubApi">Git hub api.</param>
        /// <param name="meteoriteRepository">Meteorite repository.</param>
        /// <param name="transaction">Transaction.</param>
        public MeteoriteService(
            IGitHubApi gitHubApi,
            IMeteoriteRepository meteoriteRepository,
            ITransaction transaction)
        {
            this.gitHubApi = gitHubApi;
            this.meteoriteRepository = meteoriteRepository;
            this.transaction = transaction;
        }

        /// <inheritdoc />
        public async Task ActualizationMeteoritesAsync(CancellationToken token)
        {
            var meteoritesFromApi = await this.gitHubApi.GetMeteoritesAsync(token);

            var loadedMeteorites = new List<Meteorite>();
            foreach (var meteoriteFromApi in meteoritesFromApi)
            {
                loadedMeteorites.Add(Meteorite.Create(
                    externalId: meteoriteFromApi.Id,
                    name: meteoriteFromApi.Name,
                    recClass: meteoriteFromApi.RecClass,
                    mass: meteoriteFromApi.Mass,
                    year: meteoriteFromApi.Year.Year));
            }

            var currentMateorites = await this.meteoriteRepository.GetAll(token);

            if (loadedMeteorites.OrderBy(x => x.ExternalId)
                .SequenceEqual(currentMateorites.OrderBy(x => x.ExternalId), new MeteoriteEqualityComparer()))
            {
                return;
            }

            var removedeMeteorites = currentMateorites
                .Where(x => !loadedMeteorites.Any(lm => lm.ExternalId == x.ExternalId))
                .ToList();

            var newMeteorites = new List<Meteorite>();
            var changedMeteorites = new List<Meteorite>();

            foreach (var loadedMeteorite in loadedMeteorites)
            {
                var meteorite = currentMateorites.FirstOrDefault(x => x.ExternalId == loadedMeteorite.ExternalId);

                if (meteorite is not null)
                {
                    meteorite.Change(
                        name: loadedMeteorite.Name,
                        recClass: loadedMeteorite.RecClass,
                        mass: loadedMeteorite.Mass,
                        year: loadedMeteorite.Year);

                    changedMeteorites.Add(meteorite);
                }
                else
                {
                    newMeteorites.Add(loadedMeteorite);
                }
            }

            await this.transaction.ExecuteAsync(async () =>
            {
                await this.meteoriteRepository.RemoveRangeAsync(removedeMeteorites, token);
                await this.meteoriteRepository.AddRangeAsync(newMeteorites, token);
                await this.meteoriteRepository.UpdateRangeAsync(changedMeteorites, token);
            });
        }
    }
}