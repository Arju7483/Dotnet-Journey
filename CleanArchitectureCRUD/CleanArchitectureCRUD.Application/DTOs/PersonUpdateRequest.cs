using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class PersonUpdateRequest
    {
        public Guid PersonID { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        
    }
}
