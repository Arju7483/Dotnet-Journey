using RazorViewAssignment.Models;

namespace RazorViewAssignment.Services
{
    public class WeatherData
    {
        List<CityWeather> cityWeathers = new List<CityWeather>()
{
    new CityWeather() {
        CityUniqueCode = "LDN",
        CityName = "London",
        DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
        TemperatureFahrenheit = 33
    },
    new CityWeather() {
        CityUniqueCode = "NYC",
        CityName = "New York", // Fixed from "London" in your snippet
        DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
        TemperatureFahrenheit = 60
    },
    new CityWeather() {
        CityUniqueCode = "PAR",
        CityName = "Paris",
        DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
        TemperatureFahrenheit = 82
    }
};
        public List<CityWeather> getAllData()
        {
            return cityWeathers;
        }
        public CityWeather? getByCode(string code)
        {
            CityWeather matchingWeather = cityWeathers.FirstOrDefault(x => x.CityUniqueCode == code);
            return matchingWeather;
        
        }

    }
}
