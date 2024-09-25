using Microsoft.EntityFrameworkCore;
using ReservasParking.Models; // Assuming User model is here

namespace ReservasParking.Data
{
    public class ParkingDBContext : DbContext
    {
        public DbSet<User> tbl_users { get; set; }

        public DbSet<Reservation> tbl_reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ParkingDB;Trusted_Connection=True;");
        }
    }
}