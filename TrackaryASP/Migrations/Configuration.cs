namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using TrackaryASP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrackaryASP.Models.TrackaryDbContext>
    {
        private static Boolean SEED = false;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TrackaryASP.Models.TrackaryDbContext";
        }

        protected override void Seed(TrackaryASP.Models.TrackaryDbContext context)
        {
            if (SEED)
            {
                context.Products.AddOrUpdate(
                    new Product
                    {
                        Name = "Coca Cola",
                        Description = "Refreshing beverage",
                        Price = 0.75M,
                        Quantity = 100,
                        Image = "coke.jpg"
                    },
                    new Product
                    {
                        Name = "Fanta (Orange)",
                        Description = "Orange beverage",
                        Price = 0.75M,
                        Quantity = 50,
                        Image = "fanta.jpg"
                    }
                );

                context.Customers.AddOrUpdate(
                    new Customer
                    {
                        Name = "Jay Webb",
                        Email = "jwebb@mail.utoronto.ca",
                        StudentNumber = 1000123456,
                        TCardBarcode = "2172954897462019"
                    },
                    new Customer
                    {
                        Name = "Matoi Ryouko",
                        Email = "mryouko@kiryuin.jp",
                        StudentNumber = 0999498108,
                        TCardBarcode = "1564156705671595"
                    }
                );

                //var defaults = new List<ProductDictionary>
                //{
                //    new ProductDictionary {Key = "Top", Value = 5},
                //    new ProductDictionary {Key = "Bottom", Value = 7},
                //    new ProductDictionary {Key = "Left", Value = 1},
                //    new ProductDictionary {Key = "Right", Value = 3}
                //};

                //foreach (var c in defaults)
                //    context.Carts.Add(c);
            }
        }
    }
}
