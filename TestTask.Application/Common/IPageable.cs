// <copyright file="IPageable.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    /// <summary>
    /// Interface pageable model.
    /// </summary>
    public interface IPageable
    {
        /// <summary>
        /// Gets current page number.
        /// </summary>
        public int PageNumber { get; init; }

        /// <summary>
        /// Gets number of items per page.
        /// </summary>
        public int PageSize { get; init; }
    }
}