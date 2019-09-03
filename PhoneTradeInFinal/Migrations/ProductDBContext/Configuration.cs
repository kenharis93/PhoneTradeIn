namespace PhoneTradeInFinal.Migrations.ProductDBContext
{
    using PhoneTradeInFinal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneTradeInFinal.Models.ProductDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ProductDBContext";
            ContextKey = "PhoneTradeInFinal.Models.ProductDBContext";
        }

        protected override void Seed(PhoneTradeInFinal.Models.ProductDBContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product
                {
                    Id = "APPL7",
                    Name = "iPhone 7",
                    Price = 200.00,
                    Photo = "https://i.imgur.com/pqYNAUH.jpg"
                },
                new Product
                {
                    Id = "SSGS9",
                    Name = "Samsung S9",
                    Price = 300.00,
                    Photo = "https://i.imgur.com/MGNyjD9.png"
                },
                new Product
                {
                    Id = "MOTGP",
                    Name = "Moto G Plus",
                    Price = 40.00,
                    Photo = "https://i.imgur.com/KXizLkO.jpg"
                });
        }
    }
}
