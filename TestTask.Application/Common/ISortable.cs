// <copyright file="ISortable.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    /// <summary>
    /// Interface pageable model.
    /// </summary>
    public interface ISortable
    {

        /// <summary>
        /// Gets field name to sort by.
        /// </summary>
        public string? SortField { get; init; }

        /// <summary>
        /// Gets sort direction: 1 for ascending, -1 for descending.
        /// </summary>
        public SortOrderType? SortOrder { get; init; }
    }
}