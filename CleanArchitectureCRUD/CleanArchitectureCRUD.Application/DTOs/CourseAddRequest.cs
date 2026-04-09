using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class CourseAddRequest
    {
        [Required(ErrorMessage = "Course Name can't be blank")]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Instructor ID can't be blank")]
        public Guid InstructorId { get; set; }

        [Range(1, 6, ErrorMessage = "Credit must be between 1 and 6")]
        public int Credit { get; set; }

        /// <summary>
        /// Converts the current object of CourseAddRequest into a new object of Course type
        /// </summary>
        /// <returns></returns>
        public Course ToCourse()
        {
            return new Course()
            {
                CourseId = Guid.NewGuid(),
                CourseName = CourseName,
                InstructorId = InstructorId,
                Credit = Credit
            };
        }
    }
}
