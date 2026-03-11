using ICityWeatherServices;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionAssignment.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private ICityWeatherService _weatherService;
        public HomeController(ICityWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(_weatherService.GetAllCityWeather());
        }
        [Route("/weather/{cityCode}")]
        public IActionResult GetWeatherByCode(string cityCode)
        {
            var weather = _weatherService.GetWeatherByCityCode(cityCode);
            if (weather == null)
            {
                return View("EmptyState");
            }
            else
            {
                return View("WeatherDetails",weather);
            }
            
        }
    }
}
