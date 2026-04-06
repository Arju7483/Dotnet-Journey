using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Application.Interfaces;
using CleanArchitectureCRUD.Domain;
using CleanArchitectureCRUD.Domain.Entities;
namespace CleanArchitectureCRUD.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonResponse> AddPerson(PersonAddRequest request)
        {
            Person person = request.ToPerson();
            Person response = await _personRepository.AddAsync(person);
            return response.ToPersonResponse();

        }

        public async Task<List<PersonResponse>> GetAllPerson()
        {
            List<Person> personList = await _personRepository.GetAllAsync();
            List<PersonResponse> responseList = personList.Select(x => x.ToPersonResponse()).ToList();
            return responseList;
        }
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest person)
        {
            PersonResponse response = await _personRepository.UpdatePerson(person);
            return response;
        }
    }
}
