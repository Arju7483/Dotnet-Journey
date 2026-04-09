using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid studentId);
        Task<Student> UpdateAsync(Student student);
        Task<bool> DeleteAsync(Guid studentId);
    }
}
