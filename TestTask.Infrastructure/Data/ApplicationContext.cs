// <copyright file="ApplicationContext.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Application context.
    /// </summary>
    internal class ApplicationContext : DbContext, IApplicationContext
    {
        private const string ConnStringConfigName = "SqlLiteConnection";

        private readonly IConfiguration configuration;

        /// <inheritdoc />
        public DbSet<Meteorite> Meteorites { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        /// <param name="configuration">Configuration.</param>
        public ApplicationContext(
            DbContextOptions<ApplicationContext> options,
            IConfiguration configuration)
            : base(options)
        {
            this.Database.EnsureCreated();
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.configuration.GetConnectionString(ConnStringConfigName));

#if DEBUG
            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
#endif
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}