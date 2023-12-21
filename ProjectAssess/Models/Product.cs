using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            this.ProductId = 0;
            this.Title = "";
            this.Description = "";
            this.Price = 0;
        }
    }

    public class ProductList
    {
        public List<Product> Products { get; set; }
    }
}
