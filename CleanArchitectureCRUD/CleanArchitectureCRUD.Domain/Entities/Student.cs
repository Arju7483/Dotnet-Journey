using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureCRUD.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; }

    }
}
