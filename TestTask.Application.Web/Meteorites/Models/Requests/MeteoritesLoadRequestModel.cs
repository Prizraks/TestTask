// <copyright file="MeteoritesLoadRequestModel.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web.Meteorites.Models.Requests
{
    using System.Text;

    using TestTask.Application.Common;

    /// <summary>
    /// Meteorites load request model.
    /// </summary>
    public class MeteoritesLoadRequestModel : IPageable, ISortable, IValidatable
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

        /// <inheritdoc />
        public Dictionary<string, string> Errors { get; private set; } = [];

        /// <inheritdoc />
        public bool IsValid => this.Errors.Count == 0;

        /// <summary>
        /// Gets key.
        /// </summary>
        /// <returns>Key.</returns>
        public string GetKey()
        {
            var strBuilder = new StringBuilder()
                .Append(nameof(MeteoritesLoadRequestModel))
                .Append('-')
                .Append(this.YearFrom)
                .Append('_')
                .Append(this.YearTo)
                .Append('_')
                .Append(this.RecClass)
                .Append('_')
                .Append(this.Name)
                .Append('_')
                .Append(this.PageNumber)
                .Append('_')
                .Append(this.PageSize)
                .Append('_')
                .Append(this.SortOrder)
                .Append('_')
                .Append(this.SortField);

            return strBuilder.ToString();
        }

        /// <inheritdoc />
        public void Validation()
        {
            if (this.YearFrom > this.YearTo)
            {
                this.Errors.Add(nameof(this.YearFrom), "Year from more than Year to");
            }
        }
    }
}