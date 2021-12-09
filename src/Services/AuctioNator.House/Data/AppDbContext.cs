using AuctioNator.House.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctioNator.House.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) 
        {

        }

        public DbSet<Houses> Houses { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Auctions> Auctions { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Houses>()
        //        .HasMany(p => p.Item)
        //        .WithOne(p => p.Item!)
        //        .HasForeignKey(p => p.ItemID);
        //}

    }
}
