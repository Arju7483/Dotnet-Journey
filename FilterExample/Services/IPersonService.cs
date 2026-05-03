using FilterExample.Entities;
using FilterExample.DTOs;

namespace FilterExample.Services;

public interface IPersonService
{
    Task<Person> AddPersonAsync(AddPersonDto personDto);
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<Person?> GetPersonByIdAsync(Guid id);
}
