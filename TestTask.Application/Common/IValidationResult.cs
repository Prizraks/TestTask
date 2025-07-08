// <copyright file="IValidationResult.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface validation result.
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Gets invalid fields.
        /// </summary>
        public Dictionary<string, string> InvalidFields { get; init; }
    }
}