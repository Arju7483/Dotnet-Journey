using Microsoft.EntityFrameworkCore;
using Entities;
namespace CRUDExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Country>Countries { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
