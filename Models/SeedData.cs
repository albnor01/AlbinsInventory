using AlbinsInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AlbinsInventory.Models
{
    public class SeedData //Enbartt för testsyften dennna class ingjerserar data i detabasen från Program.cs 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AlbinsInventoryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AlbinsInventoryContext>>()))
            {
                // Söker efter Items.
                if (context.Items.Any())
                {
                    return;   // Databasen har fått dattan
                }

                context.Items.AddRange( //test obijeket 
                    new Items
                    {
                        Item = "ESP3266",
                        AddedDate = DateTime.Parse("2020-2-12"),
                        Category = "ESP",
                        Price = 44
                    },

                    new Items
                    {
                        Item = "LG HG2",
                        AddedDate = DateTime.Parse("2020-3-13"),
                        Category = "batteries",
                        Price = 26
                    },

                    new Items
                    {
                        Item = "30m cat 6a cabel",
                        AddedDate = DateTime.Parse("2020-2-23"),
                        Category = "Comedy",
                        Price = 500
                    },

                    new Items
                    {
                        Item = "intel core i5 2500k",
                        AddedDate = DateTime.Parse("2020-4-15"),
                        Category = "CPU",
                        Price = 1000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
