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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567801"),
                    CourseName = "Introduction to C#",
                    InstructorId = Guid.Parse("f73fb6b0-9618-4dc9-0008-08de90cf5197"),
                    Credit = 3
                },
                new Course
                {
                    CourseId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567802"),
                    CourseName = "ASP.NET Core Web API",
                    InstructorId = Guid.Parse("74fbbc2f-7ace-4b00-0009-08de90cf5197"),
                    Credit = 4
                },
                new Course
                {
                    CourseId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567803"),
                    CourseName = "Entity Framework Core",
                    InstructorId = Guid.Parse("f73fb6b0-9618-4dc9-0008-08de90cf5197"),
                    Credit = 3
                },
                new Course
                {
                    CourseId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567804"),
                    CourseName = "Clean Architecture Principles",
                    InstructorId = Guid.Parse("74fbbc2f-7ace-4b00-0009-08de90cf5197"),
                    Credit = 4
                },
                new Course
                {
                    CourseId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567805"),
                    CourseName = "Design Patterns in .NET",
                    InstructorId = Guid.Parse("f73fb6b0-9618-4dc9-0008-08de90cf5197"),
                    Credit = 3
                }
            );
        }
    }
}
