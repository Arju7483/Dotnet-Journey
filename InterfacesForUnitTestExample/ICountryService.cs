using UnitTestServices.DTOs;

namespace InterfacesForUnitTestExample
{
    public interface ICountryService
    {
        public CountryResponse AddCountry(CountryAddRequest request);
        public List<CountryResponse> GetAll();
        public List<CountryResponse> SearchCountry(string? searchString);
    }
}
