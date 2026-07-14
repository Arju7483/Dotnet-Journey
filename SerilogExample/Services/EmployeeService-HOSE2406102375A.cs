using SerilogExample.Entities;
using SerilogExample.Interfaces;

namespace SerilogExample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository repository, ILogger<EmployeeService> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                _logger.LogWarning($"Employee not found with id = {id}");
            }
            return result;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);
        }

        public async Task RemoveEmployeeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
