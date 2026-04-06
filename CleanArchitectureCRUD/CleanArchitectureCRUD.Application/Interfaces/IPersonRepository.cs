using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddAsync (Person person);
        Task<List<Person>> GetAllAsync ();
        Task<PersonResponse> UpdatePerson(PersonUpdateRequest person);
    }
}
