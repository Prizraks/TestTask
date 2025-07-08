// <copyright file="MeteoriteParamsDto.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite.Models
{
    using TestTask.Application.Common;

    /// <summary>
    /// Meteorite params dto.
    /// </summary>
    public class MeteoriteParamsDto : IPageable, ISortable
    {
        /// <summary>
        /// Gets starting year range.
        /// </summary>
        public int? YearFrom { get; init; }

        /// <summary>
        /// Gets ending year range.
        /// </summary>
        public int? YearTo { get; init; }

        /// <summary>
        /// Gets class.
        /// </summary>
        public string? RecClass { get; init; }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string? Name { get; init; }

        /// <inheritdoc />
        public int PageNumber { get; init; }

        /// <inheritdoc />
        public int PageSize { get; init; }

        /// <inheritdoc />
        public string? SortField { get; init; }

        /// <inheritdoc />
        public SortOrderType? SortOrder { get; init; }
    }
}