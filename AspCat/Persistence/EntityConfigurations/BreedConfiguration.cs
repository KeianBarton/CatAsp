using AspCat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCat.Persistence.EntityConfigurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            // Property configurations
            builder.HasKey(b => b.Id);

            // Relationship configurations
        }
    }
}
