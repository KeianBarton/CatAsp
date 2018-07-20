using AspCat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCat.Persistence.EntityConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            // Property configurations
            builder.HasKey(l => new { l.CatId, l.LikerId });

            // Relationship configurations
            builder.HasOne(l => l.Cat)
                .WithMany(c => c.Likes)
                .OnDelete(DeleteBehavior.Restrict); // deleting cat should not delete likes
        }
    }
}
