using FilterExample.Data;
using FilterExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilterExample.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;

    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Person> AddPersonAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task<Person?> GetPersonByIdAsync(Guid id)
    {
        return await _context.Persons.FindAsync(id);
    }
}
