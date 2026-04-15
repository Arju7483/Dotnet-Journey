using EFCoreExample.Entities;
using EFCoreExample.Infrastructure;
using EFCoreExample.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddInstructor(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Instructor>> GetAllInstructor()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorById(Guid id)
        {
            return await _context.Instructors.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}

