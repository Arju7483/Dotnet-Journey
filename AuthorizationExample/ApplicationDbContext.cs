using AuthorizationExample.Entities;
using AuthorizationExample.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AuthorizationExample
{
    // Match the Guid key here as well (User, Role, KeyType)
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // CRITICAL: This configures Identity tables

            // Your custom configurations go here
        }
        public DbSet<Employee> Employees { get; set; }
    }
}