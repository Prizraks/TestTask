// <copyright file="GitHubOptions.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Integrations.Configuration
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Git Hub Options.
    /// </summary>
    public class GitHubOptions
    {
        private const string GitHubSection = "GitHubApi";

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubOptions"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public GitHubOptions(IConfiguration configuration)
        {
            configuration
                .Bind(GitHubSection, this);

            if (string.IsNullOrWhiteSpace(this.BaseUrl))
            {
                throw new InvalidOperationException($"Not find value in {GitHubSection} section.");
            }
        }

        /// <summary>
        /// Gets base url.
        /// </summary>
        public string BaseUrl { get; init; }
    }
}