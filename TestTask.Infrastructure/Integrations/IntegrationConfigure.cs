// <copyright file="IntegrationConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Integrations
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using TestTask.Application.GitHub;
    using TestTask.Application.Integration.GitHub;
    using TestTask.Infrastructure.Integrations.Configuration;

    /// <summary>
    /// Integration configure.
    /// </summary>
    internal static class IntegrationConfigure
    {
        /// <summary>
        /// Add integration Service.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddIntegrationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGitHubApi(configuration);
        }

        private static void AddGitHubApi(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient<IGitHubApi, GitHubApi>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(new GitHubOptions(configuration).BaseUrl);
                });
        }
    }
}