using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProjectMVC.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=US-5HSQ8S3;Database=ProductManagementAssess;Integrated Security=true");
        }
    }
}

