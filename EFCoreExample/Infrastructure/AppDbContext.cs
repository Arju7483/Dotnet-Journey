using EFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api
            modelBuilder.Entity<Instructor>(instructor =>
            {
                instructor.Property(x => x.Name).IsRequired().HasMaxLength(500);
                instructor.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Course>(course =>
            {
                // constraints
                course.Property(x => x.Name).IsRequired().HasMaxLength(500);
                course.HasKey(x => x.Id);
                // relations
                course.HasOne(c => c.Instructor).WithMany(x => x.Courses).HasForeignKey(i => i.InstructorId).OnDelete(DeleteBehavior.Restrict);
            });
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
