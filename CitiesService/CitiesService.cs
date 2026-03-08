using Interfaces;
namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> cities;
        public CitiesService() {
            cities = new List<string>()
            {
                "Dhaka", "Noakhali","Comilla"
            };
        }
        public List<string> GetAllCities()
        {
            return cities;
        }
    }
}
