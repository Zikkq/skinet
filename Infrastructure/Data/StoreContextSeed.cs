using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedData(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<IReadOnlyList<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        await context.ProductBrands.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<IReadOnlyList<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        await context.ProductTypes.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<IReadOnlyList<Product>>(productsData);
                    foreach (var item in products)
                    {
                        await context.Products.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.DeliveryMethods.Any())
                {
                    var dmData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<IReadOnlyList<DeliveryMethod>>(dmData);
                    foreach (var item in methods)
                    {
                        await context.DeliveryMethods.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
