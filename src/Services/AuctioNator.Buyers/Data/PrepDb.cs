using AuctioNator.Buyers.Data;
using AuctioNator.Buyers.Models;

namespace AuctioNator.Buyers.Data
{
    //Prepper min DP her
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        //Data jeg seeder min DB med.
        private static void SeedData(AppDbContext context)
        {
            if (!context.Buyers.Any())
            {
                Console.WriteLine("---> Seeding Data...");

                context.Buyers.AddRange(
                    new Buyer() { Name = "Lars", PhoneNumber = 22334455, Email = "JaViTesterLige@okay", Address = "Marc Møller Vej 12"},
                    new Buyer() { Name = "Fede Finn", PhoneNumber = 66778899, Email = "EnToTre@hej", Address = "Bellahøjvej 4" },
                    new Buyer() { Name = "Morten DillerFar", PhoneNumber = 10101111, Email = "HejMedDigMail@vises", Address = "KomBarDuVej 6" }
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