using HttpClientExample2.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientExample2.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly FinnhumService _finnhubService;
        public HomeController(FinnhumService finnhumService)
        {
            _finnhubService = finnhumService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object> response = await _finnhubService.GetStock("MSFT");

           return View();
        }

    }
}
