using FilterExample.Entities;

namespace FilterExample.Services;

public interface IEmployeeService
{
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
