using CustomModelBinder.CustomModelBinders;
using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinder.Controllers
{
    [Controller]
    public class CreateUpdateEmployeeController : Controller
    {
        [Route("/employee")]
        public IActionResult CreateEmployee([ModelBinder(BinderType = typeof(EmployeeModelBinder))] Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
