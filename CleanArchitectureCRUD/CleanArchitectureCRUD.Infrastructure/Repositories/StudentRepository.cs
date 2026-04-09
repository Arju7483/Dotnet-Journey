using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain.Entities;
using CleanArchitectureCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Student> AddAsync(Student student)
        {
            await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _appDbContext.Students.Include(c => c.Courses).ThenInclude(x => x.Instructor).ToListAsync();
            return await _appDbContext.Students
                .Include(s => s.Courses)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid studentId)
        {
            return await _appDbContext.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _appDbContext.Entry(student).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(Guid studentId)
        {
            var student = await _appDbContext.Students.FindAsync(studentId);
            if (student == null) return false;

            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
