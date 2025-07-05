// <copyright file="LoggerConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Logging
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    using Serilog;

    /// <summary>
    /// Logger configure.
    /// </summary>
    public static class LoggerConfigure
    {
        private const string AspNetCoreEnvVar = "ASPNETCORE_ENVIRONMENT";
        private const string DefaultEnv = "Production";
        private const string AppSettingsFileName = "appsettings.json";
        private const string EnvAppSettingsFileNameFormat = "appsettings.{0}.json";

        /// <summary>
        /// Configure logger.
        /// </summary>
        /// <param name="hostAction">Host action</param>
        /// <returns>Asynchronous task instance.</returns>
        public static async Task LogWebHostAsync(Func<Task> hostAction)
        {
            var currentEnv = Environment.GetEnvironmentVariable(AspNetCoreEnvVar) ?? DefaultEnv;

            var envAppSettingsFileName = string.Format(CultureInfo.InvariantCulture, EnvAppSettingsFileNameFormat, currentEnv);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(AppSettingsFileName)
                .AddJsonFile(envAppSettingsFileName)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Start web host.");
                await hostAction();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Something went wrong");
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }
        }
    }
}