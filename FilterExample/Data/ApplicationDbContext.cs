using FilterExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilterExample.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Person> Persons { get; set; }
}
