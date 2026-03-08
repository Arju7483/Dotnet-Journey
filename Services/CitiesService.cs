namespace Services
{
    public class CitiesService
    {
        private List<string> cities = new List<string>();
        public CitiesService() {
            cities = ["Dhaka", "Noakhali", "Comilla"];
        }
        public List<string> getCities()
        {
            return cities;
        }
    }
}
