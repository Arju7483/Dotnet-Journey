using AuthorizationExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationExample.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Employee> GetAllEmployee()
        {
            return _dbContext.Employees;
        }
    }
}
