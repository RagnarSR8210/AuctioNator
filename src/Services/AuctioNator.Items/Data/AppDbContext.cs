using Microsoft.EntityFrameworkCore;
using AuctioNator.Items.Models;

namespace AuctioNator.Items.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}