// <copyright file="ITransaction.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface transaction.
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Run operation in transaction and return data <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Return data type.</typeparam>
        /// <param name="operation">Operation.</param>
        /// <param name="isolationLevel">Isolation level.</param>
        /// <returns>Asynchronous task instance, what return data.</returns>
        Task<T> ExecuteAsync<T>(Func<Task<T>> operation, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Run operation in transaction.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <param name="isolationLevel">Isolation level.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task ExecuteAsync(Func<Task> operation, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}