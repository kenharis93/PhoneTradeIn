using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneTradeInFinal.Models
{
    public class ProductModel
    {
        private List<Product> products;

        public ProductModel()
        {

            this.products = new List<Product>()
            {
                new Product
                {
                    Id="APPLX",
                    Name="iPhone X",
                    Price= 400.00,
                    Photo= "IphoneX.png"
                },
                new Product
                {
                    Id="APPL7",
                    Name="iPhone 7",
                    Price= 200.00,
                    Photo= "Iphone7.jpg"
                },
                new Product
                {
                    Id="SSGS9",
                    Name="Samsung S9",
                    Price= 300.00,
                    Photo= "SamsungS9.png"
                },
                new Product
                {
                    Id="MOTGP",
                    Name="Moto G Plus",
                    Price= 40.00,
                    Photo= "MotoGPlus.jpg"
                }
            };

        }

        public List<Product> getAll()
        {
            return this.products;
        }

        public Product find(string id)
        {            
            return this.products.Single(p => p.Id == id);
        }
    }
}