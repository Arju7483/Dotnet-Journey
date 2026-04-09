using CleanArchitectureCRUD.Domain.Entities;
using System;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class CourseResponse
    {
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public Guid InstructorId { get; set; }
        public int Credit { get; set; }
        public Person Instructor { get; set; }
    }

    public static class CourseExtensions
    {
        /// <summary>
        /// Converts a Course entity into a CourseResponse DTO
        /// </summary>
        public static CourseResponse ToCourseResponse(this Course course)
        {
            return new CourseResponse()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                InstructorId = course.InstructorId,
                Credit = course.Credit,
                Instructor = course.Instructor
            };
        }
    }
}
