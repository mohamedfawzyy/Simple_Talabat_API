using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data.DataSeeding
{
    public  class StoreContextSeed
    {
        public static async Task SeedData(StoreContext storeContext) {

            if (storeContext.Brands.Count() == 0) {

                var JsonBrands = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
                var Brands=JsonSerializer.Deserialize<List<ProductBrand>>(JsonBrands);
                if (Brands?.Count() > 0) { 
                    foreach (var Brand in Brands) { 
                        await storeContext.Set<ProductBrand>().AddAsync(Brand);
                    }
                    await storeContext.SaveChangesAsync();
                }

            }
            if (storeContext.Categories.Count() == 0)
            {

                var JsonBrands = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(JsonBrands);
                if (Categories?.Count() > 0)
                {
                    foreach (var Category in Categories)
                    {
                        await storeContext.Set<ProductCategory>().AddAsync(Category);
                    }
                    await storeContext.SaveChangesAsync();
                }
                
            }
            if (storeContext.Products.Count() == 0)
            {

                var JsonProducts = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(JsonProducts);
                if (Products?.Count() > 0)
                {
                    foreach (var Product in Products)
                    {
                        await storeContext.Set<Product>().AddAsync(Product);
                    }
                    await storeContext.SaveChangesAsync();
                }

            }

        }
    }
}
