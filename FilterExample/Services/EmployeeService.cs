using FilterExample.Entities;
using FilterExample.Repository;

namespace FilterExample.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        // Add any business logic/validation here
        return await _repository.AddEmployeeAsync(employee);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _repository.GetAllEmployeesAsync();
    }
}
