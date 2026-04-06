using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CleanArchitectureCRUD.Domain.Entities;

namespace CleanArchitectureCRUD.Application.DTOs
{
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
    }
    public static class ExtensionMethod
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                Email = person.Email,
                Age = person.DateOfBirth.HasValue
                    ? DateTime.Now.Year - person.DateOfBirth.Value.Year
                      - (DateTime.Now.DayOfYear < person.DateOfBirth.Value.DayOfYear ? 1 : 0)
                    : null,
                Gender = person.Gender,
                CountryID = person.CountryID,
                Address = person.Address
            };
        }
    }
}
