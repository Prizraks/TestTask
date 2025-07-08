// <copyright file="ICacheManager.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application
{
    using System;

    /// <summary>
    /// Cache manager.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Get or set value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="fetchFunction">Fetch function.</param>
        /// <param name="cacheDuration">Cache duration.</param>
        /// <returns>Value.</returns>
        Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetchFunction, TimeSpan cacheDuration);
    }
}