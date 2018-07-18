﻿using AspCat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCat.Persistence.EntityConfigurations
{
    public class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            // Property configurations
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.BirthDate)
                .IsRequired();

            builder.Property(c => c.Weight)
                .IsRequired();

            // Relationship configurations
        }
    }
}