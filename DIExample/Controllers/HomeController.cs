using Microsoft.AspNetCore.Mvc;
using Services;
namespace DIExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly CitiesService _cityService;
        public HomeController()
        {
            _cityService = new CitiesService();
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(_cityService.getCities());
        }
    }
}
