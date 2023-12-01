using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApp.Entities;

namespace RestApp.DataAccess.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations", "dbo");
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.UserId);
        }
    }
}