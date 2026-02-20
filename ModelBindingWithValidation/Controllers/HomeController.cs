using Microsoft.AspNetCore.Mvc;
using ModelBindingWithValidation.Models;

namespace ModelBindingWithValidation.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/employee")]
        public IActionResult getEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                
                var errorList = ModelState.Values.Where(x => x.Errors.Count()>0).ToList();
                return BadRequest(errorList);
            }
            return Ok("request received");
        }
    }
}
