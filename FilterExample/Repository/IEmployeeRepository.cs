using FilterExample.Entities;

namespace FilterExample.Repository;

public interface IEmployeeRepository
{
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
