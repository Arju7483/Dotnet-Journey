
using InterfacesForUnitTestExample;
using UnitTestServices.DTOs;
using Entities;
using UnitTestServices.Helpers;
namespace UnitTestServices
{
    public class CountryService : ICountryService
    {
        private List<Country>_countryList;
        public CountryService()
        {
            _countryList = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request)); 
            }
            if (request.CountryName == null)
            {
                throw new ArgumentException(nameof(request.CountryName));
            }
            // model validation
            ValidationHelper.ModelValidator(request);

            Country country = new Country()
            {
                CountryId = Guid.NewGuid(),
                CountryName = request.CountryName,
            };
            _countryList.Add(country);
            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAll()
        {
            List<CountryResponse> _countryResponseList = _countryList.Select(x => x.ToCountryResponse()).ToList();
            return _countryResponseList;
        }

        // search country by country name
        public List<CountryResponse> SearchCountry(string? searchString)
        {
            List<CountryResponse>allCountries = GetAll();
            List<CountryResponse> matchingCountry = new List<CountryResponse>();
            if(string.IsNullOrEmpty(searchString)) { return allCountries; }
            matchingCountry = _countryList.Where(x => x.CountryName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).Select(c => c.ToCountryResponse()).ToList();
            return matchingCountry;
        }
    }
}
