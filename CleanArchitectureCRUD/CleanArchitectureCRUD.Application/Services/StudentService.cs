using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureCRUD.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<StudentResponse> AddStudent(StudentAddRequest request)
        {
            Student student = request.ToStudent();

            if (request.CourseIds != null && request.CourseIds.Any())
            {
                student.Courses = new List<Course>();
                foreach (var courseId in request.CourseIds)
                {
                    var course = await _courseRepository.GetByIdAsync(courseId);
                    if (course != null)
                    {
                        student.Courses.Add(course);
                    }
                }
            }

            Student savedStudent = await _studentRepository.AddAsync(student);
            return savedStudent.ToStudentResponse();
        }

        public async Task<List<StudentResponse>> GetAllStudents()
        {
            List<Student> students = await _studentRepository.GetAllAsync();
            return students.Select(s => s.ToStudentResponse()).ToList();
        }

        public async Task<StudentResponse?> GetStudentById(Guid studentId)
        {
            Student? student = await _studentRepository.GetByIdAsync(studentId);
            return student?.ToStudentResponse();
        }

        public async Task<StudentResponse> UpdateStudent(StudentUpdateRequest request)
        {
            Student? existingStudent = await _studentRepository.GetByIdAsync(request.Id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            existingStudent.Name = request.Name;
            existingStudent.Email = request.Email;

            if (request.CourseIds != null)
            {
                existingStudent.Courses = new List<Course>();
                foreach (var courseId in request.CourseIds)
                {
                    var course = await _courseRepository.GetByIdAsync(courseId);
                    if (course != null)
                    {
                        existingStudent.Courses.Add(course);
                    }
                }
            }

            Student updatedStudent = await _studentRepository.UpdateAsync(existingStudent);
            return updatedStudent.ToStudentResponse();
        }

        public async Task<bool> DeleteStudent(Guid studentId)
        {
            return await _studentRepository.DeleteAsync(studentId);
        }
    }
}
