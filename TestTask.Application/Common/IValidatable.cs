// <copyright file="IValidatable.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface validatable.
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Gets validation errors.
        /// </summary>
        public Dictionary<string, string> Errors { get; }

        /// <summary>
        /// Gets a value indicating whether gets is valid.
        /// </summary>
        public bool IsValid { get; }

        /// <summary>
        /// Validation.
        /// </summary>
        public void Validation();
    }
}