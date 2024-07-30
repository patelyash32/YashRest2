using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
