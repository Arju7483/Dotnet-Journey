using CustomModelValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelValidation.Controllers
{
    [Controller]
    public class CreateUpdateEmployeeController: Controller
    {
        List<Employee> employees = new List<Employee>();
        [Route("/create")]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                employees.Add(emp);
                return Ok();
            }
            else
            {
                var error = ModelState.Values.Where(x => x.Errors.Count() > 0).ToList();
                return BadRequest(error);
            }
            
        }
    }
}
