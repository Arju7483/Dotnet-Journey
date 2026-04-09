using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> AddAsync(Course course);
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid courseId);
        Task<Course> UpdateAsync(Course course);
        Task<bool> DeleteAsync(Guid courseId);
    }
}
