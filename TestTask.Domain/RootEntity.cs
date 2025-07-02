// <copyright file="RootEntity.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Domain
{
    /// <summary>
    /// Root entity.
    /// </summary>
    /// <typeparam name="T">Type Id of entity.</typeparam>
    public abstract class RootEntity<T>
        where T : struct
    {
        /// <summary>
        /// Gets id.
        /// </summary>
        public T Id { get; }
    }
}
