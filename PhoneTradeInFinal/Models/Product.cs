using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneTradeInFinal.Models
{
    public class Product
    {
        [Required]
        public string  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public double Price { get; set; }
        [Required]
        [Url]
        public string Photo { get; set; }
    }
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}