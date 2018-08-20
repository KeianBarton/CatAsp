using AspCat.Models;
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

            builder.Property(c => c.IsDeceased)
                .IsRequired();

            builder.Property(c => c.DeathDate)
                .IsRequired(false);

            builder.Property(c => c.Weight)
                .IsRequired();

            builder.Property(c => c.BreedId)
                .IsRequired();

            builder.Property(c => c.OwnerId)
                .IsRequired();

            builder.Property(c => c.IsDeleted)
               .IsRequired();

            // Relationship configurations
        }
    }
}
