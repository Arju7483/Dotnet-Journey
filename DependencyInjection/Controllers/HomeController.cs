using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private ICitiesService _services;
        public HomeController(ICitiesService services)
        {
            _services = services;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(_services.GetAllCities());
        }
    }
}
