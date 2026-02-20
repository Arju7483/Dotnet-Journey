using System.ComponentModel.DataAnnotations;

namespace CustomModelBinder.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
