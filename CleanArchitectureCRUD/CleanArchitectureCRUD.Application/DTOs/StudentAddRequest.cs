using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class StudentAddRequest
    {
        [Required(ErrorMessage = "Student Name can't be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email")]
        public string? Email { get; set; }

        public List<Guid>? CourseIds { get; set; }

        /// <summary>
        /// Converts the current object of StudentAddRequest into a new object of Student type
        /// </summary>
        /// <returns></returns>
        public Student ToStudent()
        {
            return new Student()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Email = Email
            };
        }
    }
}
