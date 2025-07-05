// <copyright file="LoggingConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Logging configure.
    /// </summary>
    public static class LoggingConfigure
    {
        private const string AppSettingFileName = "appsettings.json";
        private const string AspNetCoreEnvironmentVar = "ASPNETCORE_ENVIRONMENT";
        private const string EnvironmentAppSettingsFileFormat = "appsettings.{0}.json";
        private const string DefaultEnv = "Production";
    }
}