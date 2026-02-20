using Microsoft.AspNetCore.Mvc;
using ModelBinding_Section7.Model;
namespace ModelBinding_Section7.Controllers
{
    [Controller]
    public class EmployeeController : Controller
    {
        // Employee?id=id&isLogged=true
        [Route("/Employee")]
        public IActionResult getById(int? id)
        {
            if(id.HasValue == false)
            {
                return BadRequest("Id not found"); 
            }
            return Ok($"Employee with id {id} is xyz");
        }
        // Taking data from route parameter
        // we will pass data in both way but it receive from route because of priority
        // Employee/id/true?id=id&isLogged=true
        [Route("/Employee/{id?}/{islogged?}")]
        public IActionResult getById2(int? id, bool? islogged)
        {
            if(id.HasValue == false || islogged.HasValue == false)
            {
                return BadRequest();
            }
            
            if (!islogged.Value)
            {
                return Unauthorized("Must be logged");
            }
            return Ok($"Request received with id {id}");
        }

        // take one value from query string and one from route data
        [Route("/EmployeeInfo/{id?}/{name?}")]
        public IActionResult getById3([FromRoute] int? id, [FromQuery] string name)
        {
            if (id.HasValue == false || name == null)
            {
                return BadRequest();
            }
            return Ok($"Request received with id {id} and name {name}");
        }

        // Action method with model, receive data from query string
        [Route("EmployeeModel")]
        public IActionResult getByModel(Employee employee)
        {
            return Ok(employee.toString());
        }
    }
}
