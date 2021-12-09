using AuctioNator.Items.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctioNator.Items.Data
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

            if (!context.Items.Any())
            {
                Console.WriteLine("---> Seeding Data...");

                context.Items.AddRange(
                    new Item() { Name = "Gammel Stol", Age = 12, Price = 12000, Maker = "Marc Møller", Brand= "Antike Stole"},
                    new Item() { Name = "Gammel Niise", Age = 90, Price = 600, Maker = "Kristian DyrHoldt", Brand = "Fede Ting" },
                    new Item() { Name = "Lyse Krone", Age = 30, Price = 260, Maker = "Morten Rasmussen", Brand = "Den anden vej" }
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