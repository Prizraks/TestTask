// <copyright file="SortOrderTypeExtension.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Common
{
    /// <summary>
    /// Sort order type extension.
    /// </summary>
    public static class SortOrderTypeExtension
    {
        private const string Asc = "ASC";
        private const string Desc = "DESC";

        /// <summary>
        /// Gets text sort order type.
        /// </summary>
        /// <param name="sortOrderType">Sort order type.</param>
        /// <returns>Text SortType</returns>
        public static string GetText(this SortOrderType? sortOrderType)
        {
            return sortOrderType switch
            {
                SortOrderType.OrderByDesc => Desc,
                SortOrderType.OrderByAsk => Asc,
                _ => Asc,
            };
        }
    }
}