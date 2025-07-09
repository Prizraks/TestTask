// <copyright file="MeteoriteEntityTypeConfigure.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Configure Meteorite entity.
    /// </summary>
    internal class MeteoriteEntityTypeConfigure : IEntityTypeConfiguration<Meteorite>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Meteorite> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.Id);

            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();

            builder
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.RecClass);
            builder.Property(x => x.Mass);
            builder.Property(x => x.Year);
        }
    }
}