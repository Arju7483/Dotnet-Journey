using CRUDInterfaces;
using CRUDInterfaces.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/person")]
        public IActionResult GetPerson()
        {
            List<PersonResponse>allPerson = _personService.GetAllPerson();
            return View(allPerson);
        }
    }
}
