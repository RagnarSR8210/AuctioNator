using Microsoft.EntityFrameworkCore;
using AuctioNator.Buyers.Models;

namespace AuctioNator.Buyers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Buyer> Buyers { get; set; }
    }
}
