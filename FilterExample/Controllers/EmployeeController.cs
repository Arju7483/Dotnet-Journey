using FilterExample.Entities;
using FilterExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee data is null.");
        }

        var result = await _employeeService.AddEmployeeAsync(employee);
        
        return Ok(new { message = "Employee added successfully", data = result });
    }
}
