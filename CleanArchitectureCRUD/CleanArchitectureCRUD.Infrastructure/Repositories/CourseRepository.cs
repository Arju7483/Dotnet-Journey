using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain.Entities;
using CleanArchitectureCRUD.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Infrastructure.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<Course> AddAsync(Course course)
        {
            // normal EF core add method
            /*  await _appDbContext.Courses.AddAsync(course);
              await _appDbContext.SaveChangesAsync();
              return course;
            */
            // using storedProcedure
            var parameters = new[]
            {
              new SqlParameter("@CourseId", course.CourseId),
              new SqlParameter("@CourseName", course.CourseName),
              new SqlParameter("@InstructorId",course.InstructorId),
              new SqlParameter("@Credit", course.Credit)
          };
            await _appDbContext.Database.ExecuteSqlRawAsync("EXEC spAddCourse @CourseId, @CourseName, @InstructorId, @Credit", parameters);
            return course;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _appDbContext.Courses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid courseId)
        {
            // eager loading
            return await _appDbContext.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            _appDbContext.Entry(course).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteAsync(Guid courseId)
        {
            var course = await _appDbContext.Courses.FindAsync(courseId);
            if (course == null) return false;

            _appDbContext.Courses.Remove(course);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
