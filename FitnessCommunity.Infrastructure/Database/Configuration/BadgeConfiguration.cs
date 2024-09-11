using FitnessCommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCommunity.Infrastructure.Database.Configuration
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(b => b.Description)
                .HasMaxLength(250);

            builder.Property(b => b.IconUrl).IsRequired();

            builder.HasMany(b => b.UserBadges)
                .WithOne(ub => ub.Badge)
                .HasForeignKey(ub => ub.BadgeId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasIndex(b => b.Name)
                .IsUnique(); 
        }
    }
}
