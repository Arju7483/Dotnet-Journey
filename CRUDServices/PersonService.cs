using CRUDInterfaces;
using CRUDInterfaces.DTOs;
using Entities;
using CRUDExample.Data;
namespace CRUDServices
{
    public class PersonService : IPersonService
    {
        private readonly  _dbContext
        public PersonService()
        {
        }
        public PersonResponse AddPerson(PersonAddRequest request)
        {
            throw new NotImplementedException();
        }

        public List<PersonResponse> GetAllPerson()
        {
            return _personList.Select(x => x.ToPersonResponse()).ToList();
        }

        public List<PersonResponse> SearchPerson(string searchField, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
