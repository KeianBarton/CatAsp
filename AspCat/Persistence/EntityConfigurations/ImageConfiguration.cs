using AspCat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCat.Persistence.EntityConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            // Property configurations
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Data)
                .IsRequired();

            builder.Property(i => i.Width)
                .IsRequired();

            builder.Property(i => i.Height)
                .IsRequired();

            builder.Property(i => i.CatId)
                .IsRequired();

            builder.Property(i => i.ContentType)
                .IsRequired()
                .HasMaxLength(50);

            // Relationship configurations
            builder.HasOne(i => i.Cat)
                .WithOne(c => c.Image)
                .HasForeignKey<Image>(i => i.CatId);
        }
    }
}
