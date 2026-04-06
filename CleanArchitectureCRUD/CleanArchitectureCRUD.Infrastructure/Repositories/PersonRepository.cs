using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain.Entities;
using CleanArchitectureCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureCRUD.Application.DTOs;
namespace CleanArchitectureCRUD.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;
        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Person> AddAsync(Person person)
        {
            _appDbContext.Persons.Add(person);
            await _appDbContext.SaveChangesAsync();
            return person;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _appDbContext.Persons.ToListAsync();
        }
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest person)
        {
            Person existing = await _appDbContext.Persons.FirstOrDefaultAsync(x => x.PersonID == person.PersonID);
            if (existing is null)
            {
                throw new Exception("Not found");
            }
            existing.PersonName = person.PersonName;
            existing.Address = person.Address;
            existing.Email = person.Email;
            existing.DateOfBirth = person.DateOfBirth;

            await _appDbContext.SaveChangesAsync();
            return existing.ToPersonResponse();
        }
    }
}
