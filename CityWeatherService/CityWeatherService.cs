using ICityWeatherServices;
using Models;
namespace CityWeatherServices
{
    public class CityWeatherService : ICityWeatherService
    {
        private List<CityWeather> _cityWeatherList;
        public CityWeatherService()
        {
            _cityWeatherList = new List<CityWeather>
            {
                new CityWeather { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },
                new CityWeather { CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },
                new CityWeather { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
            };
        }
        public List<CityWeather> GetAllCityWeather()
        {
            return _cityWeatherList;
        }

        public CityWeather? GetWeatherByCityCode(string cityCode)
        {
            return _cityWeatherList.FirstOrDefault(x => x.CityUniqueCode == cityCode);
        }
        
    }
}
