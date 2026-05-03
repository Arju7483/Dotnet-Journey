using FilterExample.Entities;
using FilterExample.Repository;
using FilterExample.DTOs;

namespace FilterExample.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Person> AddPersonAsync(AddPersonDto personDto)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Age = personDto.Age,
            Email = personDto.Email
        };

        return await _repository.AddPersonAsync(person);
    }

    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _repository.GetAllPersonsAsync();
    }

    public async Task<Person?> GetPersonByIdAsync(Guid id)
    {
        return await _repository.GetPersonByIdAsync(id);
    }
}
