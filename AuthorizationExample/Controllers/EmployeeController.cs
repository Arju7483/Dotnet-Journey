
using AuthorizationExample.DTOs;
using AuthorizationExample.Entities;
using AuthorizationExample.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository repo)
        {
            _employeeRepository = repo;
        }

        [Authorize(Roles = "Admin")]
        [Route("add-employee")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Pass ModelState to show specific validation errors
            }

            Employee newEmployee = new Employee()
            {
                Id = RandomNumberGenerator.GetInt32(1, 10000),
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary
            };

            try
            {
                await _employeeRepository.CreateEmployee(newEmployee);

                return Ok(new
                {
                    Message = $"Employee is created with ID: {newEmployee.Id}",
                    Id = newEmployee.Id
                });
            }
            catch (Exception ex)
            {
                // Use Problem() for 500 errors in APIs
                return Problem(detail: ex.Message, title: "An error occurred while creating the employee.");
            }
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var query = _employeeRepository.GetAllEmployee();

            // 2. You can add more logic here if needed (Filtering, Sorting)
            // Example: query = query.Where(x => x.IsActive);

            // 3. MATERIALIZE the query into a list to hit the database
            // We use Microsoft.EntityFrameworkCore for .ToListAsync()
            var employees = await query.ToListAsync();

            return Ok(employees);
        }
    }
}
