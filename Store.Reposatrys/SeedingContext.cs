using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Reposatrys
{
    public class SeedingContext
    {
        public static async Task SeedAsync(StoreDBcontext context, ILoggerFactory factory)
        {
            try
            {
                if (context.Brands != null && !context.Brands.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(Data);
                    if (brands is not null)
                    {
                        await context.Brands.AddRangeAsync(brands);
                    }

                }
                if (context.Types != null && !context.Types.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<Data.Entites.Type>>(Data);
                    if (Types is not null)
                    {
                        await context.Types.AddRangeAsync(Types);
                    }

                }
                if (context.products != null && !context.products.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(Data);
                    if (products is not null)
                    {
                        await context.products.AddRangeAsync(products);
                    }

                }
                if (context.DlivaryMethods != null && !context.DlivaryMethods.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/delivery.json");
                    var delivry = JsonSerializer.Deserialize<List<DlivaryMethod>>(Data);
                    if (delivry is not null)
                    {
                        await context.DlivaryMethods.AddRangeAsync(delivry);
                    }

                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var loger = factory.CreateLogger<SeedingContext>();
                loger.LogError(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
        }
    }
}
