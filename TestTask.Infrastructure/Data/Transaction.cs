// <copyright file="Transaction.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using TestTask.Application;

    /// <summary>
    /// Transaction.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Transaction"/> class.
    /// </remarks>
    /// <param name="applicationContext">Application context.</param>
    /// <param name="logger">Logger.</param>
    internal class Transaction(
        ApplicationContext applicationContext,
        ILogger<Transaction> logger) : ITransaction
    {
        private readonly ApplicationContext applicationContext = applicationContext;
        private readonly ILogger<Transaction> logger = logger;

        /// <inheritdoc/>
        public async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            await using var transaction = await this.applicationContext.Database.BeginTransactionAsync(isolationLevel);
            try
            {
                var result = await operation();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Transaction failed");
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task ExecuteAsync(Func<Task> operation, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            await using var transaction = await this.applicationContext.Database.BeginTransactionAsync(isolationLevel);
            try
            {
                await operation();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Transaction failed");
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}