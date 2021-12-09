using AuctioNator.Sellers.Data;
using AuctioNator.Sellers.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctioNator.Sellers.Data
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
                Console.WriteLine("---> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"--> Could not run migrations {ex.Message}");
                }

            }


            if (!context.Sellers.Any())
            {
                Console.WriteLine("---> Seeding Data...");

                context.Sellers.AddRange(
                    new Seller() { Name = "Lars", PhoneNumber = 22334455, Email = "JaViTesterLige@okay", Address = "Marc Møller Vej 12" },
                    new Seller() { Name = "Fede Finn", PhoneNumber = 66778899, Email = "EnToTre@hej", Address = "Bellahøjvej 4" },
                    new Seller() { Name = "Morten DillerFar", PhoneNumber = 10101111, Email = "HejMedDigMail@vises", Address = "KomBarDuVej 6" }
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