using Models;
namespace ICityWeatherServices
{
    public interface ICityWeatherService
    {
        public List<CityWeather> GetAllCityWeather();
        public CityWeather? GetWeatherByCityCode(string cityCode);
    }
}
