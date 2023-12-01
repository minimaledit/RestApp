using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApp.Entities;

namespace RestApp.DataAccess.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables", "dbo").HasKey(t => t.Id);
            builder.HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.RestaurantId);
        }
    }
}