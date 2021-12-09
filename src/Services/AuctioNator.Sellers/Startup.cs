using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AuctioNator.Sellers.Data;
using AuctioNator.Sellers.SyncDataService.Http;

namespace AuctioNator.Sellers

{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly IWebHostEnvironment _env;


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
            {
                Console.WriteLine("---> Using SqlServer Db");
                services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("SellersConn")));

            }
            else
            {
                Console.WriteLine("---> Using InMem Db");
                services.AddDbContext<AppDbContext>(opt =>           
                opt.UseInMemoryDatabase("InMem"));
            }
           


            services.AddScoped<ISellersRepo, SellersRepo>();
            services.AddHttpClient<IHouseDataClient, HttpHouseDataClient>();


            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuctioNator.Sellers", Version = "v1" });
            });

            Console.WriteLine($"---> HouseService   Endpoint: {_configuration["AuctioNator.House"]}");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.jason", "AuctioNator.Sellers v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.PrepPopulation(app, env.IsProduction());

        }
    }
}