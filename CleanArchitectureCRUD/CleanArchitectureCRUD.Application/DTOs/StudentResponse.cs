using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<CourseResponse>? Courses { get; set; }
    }

    public static class StudentExtensions
    {
        /// <summary>
        /// Converts a Student entity into a StudentResponse DTO
        /// </summary>
        public static StudentResponse ToStudentResponse(this Student student)
        {
            return new StudentResponse()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Courses = student.Courses?
                    .Select(c => c.ToCourseResponse())
                    .ToList()
            };
        }
    }
}
