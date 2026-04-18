using Microsoft.AspNetCore.Mvc;
using SerilogExample.Entities;
using SerilogExample.Interfaces;

namespace SerilogExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService service, ILogger<EmployeesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            _logger.LogInformation("Fetching all employees");
            var employees = await _service.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            _logger.LogInformation("Fetching employee with id {Id}", id);
            var employee = await _service.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                _logger.LogWarning("Employee with id {Id} not found", id);
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _logger.LogInformation("Creating employee {@Employee}", employee);
            await _service.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _logger.LogInformation("Updating employee with id {Id}", id);
            await _service.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _logger.LogInformation("Deleting employee with id {Id}", id);
            await _service.RemoveEmployeeAsync(id);
            return NoContent();
        }
    }
}
