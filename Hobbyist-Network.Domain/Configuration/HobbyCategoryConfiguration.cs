using Hobbyist_Network.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hobbyist_Network.Domain.Configuration
{
    public class HobbyCategoryConfiguration : IEntityTypeConfiguration<HobbyCategory>
    {
        public void Configure(EntityTypeBuilder<HobbyCategory> builder)
        {
            builder.HasKey(hc => hc.Id);

            builder.HasMany(hc => hc.Hobbies)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId);

            builder.HasMany(hc => hc.Events)
                   .WithOne(e => e.Category)
                   .HasForeignKey(e => e.CategoryId);

            builder.Metadata.FindNavigation(nameof(HobbyCategory.Hobbies))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(HobbyCategory.Events))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
