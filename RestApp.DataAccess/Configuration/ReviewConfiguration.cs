using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApp.Entities;
using System.Reflection.Metadata;

namespace RestApp.DataAccess.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews", "dbo");
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Restaurant)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.RestaurantId);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
        }
    }
}