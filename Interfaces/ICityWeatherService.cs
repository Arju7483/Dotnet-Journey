using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionAssignment.Models;
namespace Interfaces
{
    public interface ICityWeatherService
    {
        public List<CityWeather> GetAllCityWeathers();
        public CityWeather? GetCityWeatherByCode(string cityCode);
    }
}
