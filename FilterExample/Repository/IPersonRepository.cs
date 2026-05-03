using FilterExample.Entities;

namespace FilterExample.Repository;

public interface IPersonRepository
{
    Task<Person> AddPersonAsync(Person person);
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<Person?> GetPersonByIdAsync(Guid id);
}
