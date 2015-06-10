using System.Data.Entity;

namespace TrackaryASP.Models
{
    public class TrackaryDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}