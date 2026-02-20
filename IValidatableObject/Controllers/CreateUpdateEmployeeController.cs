using IValidatableObjectExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IValidatableObjectExample.Controllers
{
    [Controller]
    public class CreateUpdateEmployeeController : Controller
    {
        [Route("/employee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok("Created successfully");
            }
            else
            {
                //var errors = ModelState.Values.Where(err => err.Errors.Count()> 0);
                return BadRequest(ModelState);
            }
        }
    }
}
