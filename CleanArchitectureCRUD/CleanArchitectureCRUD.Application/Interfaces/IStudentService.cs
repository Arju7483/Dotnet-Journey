using CleanArchitectureCRUD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentResponse> AddStudent(StudentAddRequest request);
        Task<List<StudentResponse>> GetAllStudents();
        Task<StudentResponse?> GetStudentById(Guid studentId);
        Task<StudentResponse> UpdateStudent(StudentUpdateRequest request);
        Task<bool> DeleteStudent(Guid studentId);
    }
}
