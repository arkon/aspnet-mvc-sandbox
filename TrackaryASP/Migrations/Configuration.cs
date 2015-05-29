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
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TrackaryASP.Models.TrackaryDbContext";
        }

        protected override void Seed(TrackaryASP.Models.TrackaryDbContext context)
        {
            if (SEED)
            {
                context.Products.AddOrUpdate(
                    new Product
                    {
                        ID = 0,
                        Name = "Coca Cola",
                        Description = "Refreshing beverage",
                        Price = 0.75M,
                        Reward = 0.10M,
                        Quantity = 100,
                        Image = "coke.jpg"
                    },
                    new Product
                    {
                        ID = 1,
                        Name = "Fanta (Orange)",
                        Description = "Orange beverage",
                        Price = 0.75M,
                        Reward = 0.10M,
                        Quantity = 50,
                        Image = "fanta.jpg"
                    },
                    new Product
                    {
                        ID = 2,
                        Name = "Red Bull",
                        Description = "Gives you wings!",
                        Price = 2.50M,
                        Reward = 0.50M,
                        Quantity = 20,
                        Image = "redbull.jpg"
                    }
                );

                context.Customers.AddOrUpdate(
                    new Customer
                    {
                        ID = 0,
                        Name = "Jay Webb",
                        Email = "jwebb@mail.utoronto.ca",
                        StudentNumber = 1000123456,
                        UTORid = "webbjo123",
                        TCardBarcode = "2172954897462019"
                    },
                    new Customer
                    {
                        ID = 1,
                        Name = "Matoi Ryouko",
                        Email = "mryouko@kiryuin.jp",
                        StudentNumber = 0999498108,
                        UTORid = "ryouko666",
                        TCardBarcode = "1564156705671595"
                    }
                );
            }
        }
    }
}
