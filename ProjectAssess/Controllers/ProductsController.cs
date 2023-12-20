using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using ProjectMVC.Models;
using System.Collections.Immutable;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

namespace ProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Product> products = await GetProducts();
            return View(products);
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> product = new List<Product>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    ProductList productlist = JsonConvert.DeserializeObject<ProductList>(jsonContent);
                    productlist.Products.ForEach(products => product.Add(products));
                }
                var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("Server=US-5HSQ8S3;Database=ProductManagementAssess;Integrated Security=true")
            .Options;

                using (var dbContext = new DataContext(options))
                {
                    foreach (var item in product)
                    {
                        dbContext.Products.Add(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
                return product;
            }
        }
        [HttpPost]
        public IActionResult AddToFavourites(Product product)
        {
            return RedirectToAction("Index");
        }
    }
}
