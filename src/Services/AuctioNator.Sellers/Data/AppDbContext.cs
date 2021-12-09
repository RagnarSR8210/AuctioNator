using Microsoft.EntityFrameworkCore;
using AuctioNator.Sellers.Models;

namespace AuctioNator.Sellers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Seller> Sellers { get; set; }
    }
}
