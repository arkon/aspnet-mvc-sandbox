namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrackaryASP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrackaryASP.Models.TrackaryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrackaryASP.Models.TrackaryDbContext";
        }

        protected override void Seed(TrackaryASP.Models.TrackaryDbContext context)
        {
            context.Products.AddOrUpdate(
                new Product {
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
        }
    }
}
