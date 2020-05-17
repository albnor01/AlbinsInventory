using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AlbinsInventory.Models;

namespace AlbinsInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) //för testsydte att ta expel data skappad i /Models/SeedData.cd
            {
                var services = scope.ServiceProvider; //öpnar en upkopling till databasen

                try //försöker anropa metoden som skickar vidare dattan till databasen 
                {
                    SeedData.Initialize(services);
                }
                catch (Exception ex)//om error upstår 
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();//hämtar feldatan från lggen 
                    logger.LogError(ex, "An error occurred seeding the Database ."); //errror medelande vid felaktig inmatnig i databasen 
                }
            }

            host.Run(); //anger svaret från dattabasen 

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
