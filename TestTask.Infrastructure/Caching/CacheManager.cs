// <copyright file="CacheManager.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Caching
{
    using System;

    using Microsoft.Extensions.Caching.Memory;

    using TestTask.Application;

    /// <summary>
    /// Cache manager.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CacheManager"/> class.
    /// </remarks>
    /// <param name="memoryCache">Memory cache.</param>
    public class CacheManager(IMemoryCache memoryCache) : ICacheManager
    {
        private readonly IMemoryCache memoryCache = memoryCache;

        /// <inheritdoc />
        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> fetchFunction, TimeSpan cacheDuration)
        {
            if (!this.memoryCache.TryGetValue(key, out T value))
            {
                value = await fetchFunction();
                this.memoryCache.Set(key, value, cacheDuration);
            }

            return value;
        }
    }
}