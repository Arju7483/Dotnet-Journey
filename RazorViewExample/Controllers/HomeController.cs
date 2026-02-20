using Microsoft.AspNetCore.Mvc;

namespace RazorViewExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/home")]
        public IActionResult getHomeInfo()
        {
            return View("HomeInfo");
        }
    }
}
