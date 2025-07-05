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

    using Microsoft.Extensions.Logging;

    using TestTask.Application.GitHub;
    using TestTask.Application.Meteorite.Comparers;
    using TestTask.Application.Meteorite.Services.Contracts;
    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Meteorite service.
    /// </summary>
    internal class MeteoriteService : IMeteoriteService
    {
        private const string FallText = "Fell";

        private readonly IGitHubApi gitHubApi;
        private readonly IMeteoriteRepository meteoriteRepository;
        private readonly ITransaction transaction;
        private readonly ILogger<MeteoriteService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeteoriteService"/> class.
        /// </summary>
        /// <param name="gitHubApi">Git hub api.</param>
        /// <param name="meteoriteRepository">Meteorite repository.</param>
        /// <param name="transaction">Transaction.</param>
        /// <param name="logger">Logger.</param>
        public MeteoriteService(
            IGitHubApi gitHubApi,
            IMeteoriteRepository meteoriteRepository,
            ITransaction transaction,
            ILogger<MeteoriteService> logger)
        {
            this.gitHubApi = gitHubApi;
            this.meteoriteRepository = meteoriteRepository;
            this.transaction = transaction;
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task ActualizationMeteoritesAsync(CancellationToken token)
        {
            var meteoritesFromApi = await this.gitHubApi.GetMeteoritesAsync(token);

            var loadedMeteorites = new List<Meteorite>();
            foreach (var meteoriteFromApi in meteoritesFromApi)
            {
                if (!Enum.TryParse(meteoriteFromApi.NameType, out NameType nameType))
                {
                    string message = $"Incorrect format {nameof(meteoriteFromApi.NameType)}. Value from Api = {meteoriteFromApi.NameType}!";
                    this.logger.LogError(message: message);
                    return;
                }

                loadedMeteorites.Add(Meteorite.Create(
                    externalId: meteoriteFromApi.Id,
                    name: meteoriteFromApi.Name,
                    nameType: nameType,
                    recClass: meteoriteFromApi.RecClass,
                    mass: meteoriteFromApi.Mass,
                    fall: meteoriteFromApi.Fall == FallText,
                    year: meteoriteFromApi.Year.Year,
                    latitude: meteoriteFromApi.Reclat,
                    longitude: meteoriteFromApi.Reclong));
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
                        nameType: loadedMeteorite.NameType,
                        recClass: loadedMeteorite.RecClass,
                        mass: loadedMeteorite.Mass,
                        fall: loadedMeteorite.Fall,
                        year: loadedMeteorite.Year,
                        latitude: loadedMeteorite.Latitude,
                        longitude: loadedMeteorite.Longitude);

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