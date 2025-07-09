// <copyright file="QueryableExtension.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Repositories.Extensions
{
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Queryable extension.
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// Order by field.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="source">Source.</param>
        /// <param name="fieldName">FieldName.</param>
        /// <param name="descending">Descending.</param>
        /// <returns>IOrderedQueryable data.</returns>
        public static IOrderedQueryable<T> OrderByField<T>(
            this IQueryable<T> source,
            string fieldName,
            bool descending = false)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var prop = Expression.Property(param, fieldName);
            var lambda = Expression.Lambda(prop, param);

            var methodName = descending ? nameof(Queryable.OrderByDescending) : nameof(Queryable.OrderBy);
            var methodCall = Expression.Call(
                typeof(Queryable),
                methodName,
                [typeof(T), prop.Type],
                source.Expression,
                Expression.Quote(lambda));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(methodCall);
        }
    }
}