using System;
using System.Collections.Generic;
using CleanArchitectureCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCRUD.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
