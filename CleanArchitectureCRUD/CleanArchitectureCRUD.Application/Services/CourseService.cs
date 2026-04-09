using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IPersonRepository _personRepository;
        public CourseService(ICourseRepository courseRepository, IPersonRepository personRepository)
        {
            _courseRepository = courseRepository;
            _personRepository = personRepository;
        }

        public async Task<CourseResponse> AddCourse(CourseAddRequest request)
        {
            Course course = request.ToCourse();
            Person instructor = await _personRepository.GetPersonByIdAsync(course.InstructorId);
            course.Instructor = instructor;
            Course result = await _courseRepository.AddAsync(course);
            return result.ToCourseResponse();
        }

        public async Task<List<CourseResponse>> GetAllCourses()
        {
            List<Course> courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => c.ToCourseResponse()).ToList();
        }

        public async Task<CourseResponse?> GetCourseById(Guid courseId)
        {
            Course? course = await _courseRepository.GetByIdAsync(courseId);
            return course?.ToCourseResponse();
        }

        public async Task<CourseResponse> UpdateCourse(CourseUpdateRequest request)
        {
            Course course = request.ToCourse();
            Course result = await _courseRepository.UpdateAsync(course);
            return result.ToCourseResponse();
        }

        public async Task<bool> DeleteCourse(Guid courseId)
        {
            return await _courseRepository.DeleteAsync(courseId);
        }
    }
}
