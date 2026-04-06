using CRUDInterfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDInterfaces
{
    public interface IPersonService
    {
        public PersonResponse AddPerson(PersonAddRequest request);
        public List<PersonResponse> GetAllPerson();
        public List<PersonResponse> SearchPerson(string searchField, string searchString);
    }
}
