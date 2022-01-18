using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var item in brands)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    {
                        await context.ProductBrands.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<IReadOnlyList<ProductType>>(typesData);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var item in types)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    {
                        await context.ProductTypes.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<IReadOnlyList<Product>>(productsData);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var item in products)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    {
                        await context.Products.AddAsync(item);
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
