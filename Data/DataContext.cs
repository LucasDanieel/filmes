using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<User> User { get; set; }
    }
}