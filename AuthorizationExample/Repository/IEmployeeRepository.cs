using AuthorizationExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationExample.Repository
{
    public interface IEmployeeRepository
    {
        public Task CreateEmployee(Employee employee);
        public IQueryable<Employee> GetAllEmployee();
    }
}
