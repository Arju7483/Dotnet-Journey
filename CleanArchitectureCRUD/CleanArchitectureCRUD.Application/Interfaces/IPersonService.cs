using System;
using System.Collections.Generic;
using CleanArchitectureCRUD.Application.DTOs;

namespace CleanArchitectureCRUD.Application.Interfaces
{
    public interface IPersonService
    {
        public Task<PersonResponse> AddPerson(PersonAddRequest request);
        public Task<List<PersonResponse>> GetAllPerson();
        public Task<PersonResponse> UpdatePerson(PersonUpdateRequest person);
    }
}
