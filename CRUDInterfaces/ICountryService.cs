using CRUDInterfaces.DTOs;

namespace CRUDInterfaces
{
    public interface ICountryService
    {
        public CountryResponse AddCountry(CountryAddRequest request);
        public List<CountryResponse> GetAllCountry();
    }
}
