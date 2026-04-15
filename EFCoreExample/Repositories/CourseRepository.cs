using EFCoreExample.Entities;
using EFCoreExample.Infrastructure;
using EFCoreExample.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await _context.Courses.Include(c => c.Instructor).ToListAsync();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _context.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
