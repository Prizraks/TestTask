// <copyright file="GitHubApi.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Integration.GitHub
{
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using TestTask.Application.GitHub;
    using TestTask.Application.GitHub.Models;

    /// <summary>
    /// Api GitHub.
    /// </summary>
    internal class GitHubApi : IGitHubApi
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubApi"/> class.
        /// </summary>
        /// <param name="httpClient">Http client.</param>
        public GitHubApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MeteoriteApiModel>> GetMeteoritesAsync(CancellationToken token)
        {
            return (await this.httpClient.GetFromJsonAsync<IEnumerable<MeteoriteApiModel>>(
                "biggiko/nasa-dataset/refs/heads/main/y77d-th95.json")) ?? [];
        }
    }
}