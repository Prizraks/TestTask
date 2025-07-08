// <copyright file="LazyLoadResponseModel.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Lazy load response model.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public class LazyLoadResponseModel<T>
    {
        /// <summary>
        /// Gets list of data.
        /// </summary>
        public IEnumerable<T> Data { get; init; } = [];

        /// <summary>
        /// Gets total records.
        /// </summary>
        public int TotalRecords { get; init; }
    }
}