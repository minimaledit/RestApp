using Microsoft.EntityFrameworkCore;
using RestApp.DataAccess.Configuration;
using RestApp.Entities;

namespace RestApp.DataAccess
{
    public class RestDbContext: DbContext
    {
        public RestDbContext(DbContextOptions<RestDbContext> options) : base(options) 
        { 
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
        }
    }
}