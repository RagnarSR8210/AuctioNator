using AuctioNator.House.Data;
using AuctioNator.House.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctioNator.House.Data
{
    //Prepper min DP her
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isprod)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {

                SeedData(servicesScope.ServiceProvider.GetService<AppDbContext>(), isprod);
            }
        }

        //Data jeg seeder min DB med.
        private static void SeedData(AppDbContext context, bool isprod)
        {
            if (isprod)
            {
                Console.WriteLine("---> Attempting to apply Migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"---> Could not run migrations: {ex.Message}");
                }


            }

            if (!context.Auctions.Any())
            {
                Console.WriteLine("---> Seeding Data...");

                context.Auctions.AddRange(
                    new Auctions() { Name = "Gammel Stol", CreatedAt = DateTime.Now, Price = 12000, SellerId = "90", ExpirationDate = DateTime.Now},
                    new Auctions() { Name = "Gammel Niise", CreatedAt =DateTime.Now, Price = 600, SellerId = "21", ExpirationDate = DateTime.Now},
                    new Auctions() { Name = "Lyse Krone", CreatedAt = DateTime.Now, Price = 260, SellerId = "21", ExpirationDate = DateTime.Now}
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}