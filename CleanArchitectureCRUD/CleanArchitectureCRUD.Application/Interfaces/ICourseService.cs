using CleanArchitectureCRUD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse> AddCourse(CourseAddRequest request);
        Task<List<CourseResponse>> GetAllCourses();
        Task<CourseResponse?> GetCourseById(Guid courseId);
        Task<CourseResponse> UpdateCourse(CourseUpdateRequest request);
        Task<bool> DeleteCourse(Guid courseId);
    }
}
