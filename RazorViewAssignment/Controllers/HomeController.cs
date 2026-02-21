using Microsoft.AspNetCore.Mvc;
using RazorViewAssignment.Models;
using RazorViewAssignment.Services;

namespace RazorViewAssignment.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly WeatherData _weatherData = new WeatherData();
        [Route("/")]
        public IActionResult AllCityWeather()
        {
            return View(_weatherData.getAllData());
        }
        [Route("/weather/{cityCode?}")]
        public IActionResult WetherDetails(string? cityCode)
        {
            CityWeather? matchingData = _weatherData.getAllData().FirstOrDefault(x => x.CityUniqueCode == cityCode);

            if(matchingData is null)
            {
                return View("NotFoundPage");
            }
            else
            {
                return View(matchingData);
            }
        }
    }
}
