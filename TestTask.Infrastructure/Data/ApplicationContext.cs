// <copyright file="ApplicationContext.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Application context.
    /// </summary>
    internal class ApplicationContext : DbContext, IApplicationContext
    {
        private const string ConnStringConfigName = "name=ConnectionStrings:SqlLiteConnection";

        /// <inheritdoc />
        public DbSet<Meteorite> Meteorites { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
#if DEBUG
            this.Database.EnsureCreated();
#endif
        }

        /// <inheritdoc/>
        public async Task SaveAsync(CancellationToken token)
        {
            await this.SaveChangesAsync(token);
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(connectionString: ConnStringConfigName);

#if DEBUG
            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
#endif
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}