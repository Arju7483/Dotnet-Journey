using Microsoft.AspNetCore.Mvc;

namespace Environments.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        // accessing environment in controller
        private readonly IWebHostEnvironment _enviroment;
        public HomeController(IWebHostEnvironment enviroment)
        {
            this._enviroment = enviroment;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return Ok(_enviroment.EnvironmentName);
        }
    }
}
