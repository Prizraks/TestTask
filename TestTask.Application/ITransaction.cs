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
        /// Run operation in transaction.
        /// </summary>
        /// <param name="operation">Operation.</param>
        /// <param name="isolationLevel">Isolation level.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task ExecuteAsync(Func<Task> operation, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}