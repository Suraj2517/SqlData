using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int prodcutId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        public Product()
        {
            this.prodcutId = 0;
            this.title = "";
            this.description = "";
            this.price = 0;
        }
    }

    public class ProductList
    {
        public List<Product> Products { get; set; }
    }
}
