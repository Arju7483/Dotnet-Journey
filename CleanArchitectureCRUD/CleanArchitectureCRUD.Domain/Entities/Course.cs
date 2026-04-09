using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureCRUD.Domain.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid InstructorId { get; set; }
        public int Credit {  get; set; }
        public Person Instructor { get; set; }
    }
}
