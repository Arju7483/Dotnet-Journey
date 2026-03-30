using UnitTestServices.DTOs;
using InterfacesForUnitTestExample;
using UnitTestServices;
namespace Tests
{
    public class CountryServiceTest
    {
        private readonly ICountryService _ICountryService;
        public CountryServiceTest()
        {
            _ICountryService = new CountryService();
        }
        #region AddCountryTest
        // add country with null argument
        [Fact]
        public void AddCountry_NullArgument()
        {
            CountryAddRequest? request = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ICountryService.AddCountry(request);
            });
        }

        // add country with null country name
        [Fact]
        public void AddCountry_NullCountryName()
        {
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = null
            };
            Assert.Throws<ArgumentException>(() =>
            {
                _ICountryService.AddCountry(request);
            });
        }

        // add country with proper request
        [Fact]
        public void AddCountry_WithProperRequest()
        {
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = "UAE"
            };

            CountryResponse response = _ICountryService.AddCountry(request);
            Assert.True(response.CountryId != Guid.Empty);

        }
        #endregion

        #region GetAllTest
        // getAll with empty list
        [Fact]
        public void getAll_EmptyList()
        {
            List<CountryResponse> response = _ICountryService.GetAll();
            Assert.Empty(response);
        }
        // getAll with few item
        [Fact]
        public void getAll_WithFewItems()
        {
            List<CountryAddRequest> requests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "Bangladesh" },
                new CountryAddRequest() { CountryName = "Japan" }
            };
            List<CountryResponse> individualResponse = new List<CountryResponse>();
            foreach (var request in requests)
            {
               individualResponse.Add(_ICountryService.AddCountry(request));
            }
            List<CountryResponse> responseFromGetAll = _ICountryService.GetAll();
            foreach (var response in individualResponse)
            {
                Assert.Contains(response, responseFromGetAll);
            }

        }
        #endregion

        #region SearchCountry 
        // case - 1: search with empty string -> return all country
        [Fact]
        public void SearchCountry_EmptyString()
        {
            List<CountryAddRequest> requests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "Bangladesh" },
                new CountryAddRequest() { CountryName = "Japan" }
            };
            List<CountryResponse>? individualResponse = new List<CountryResponse>();
            foreach (var request in requests)
            {
                individualResponse.Add(_ICountryService.AddCountry(request));
            }
            List<CountryResponse>? responseFromSearch = _ICountryService.SearchCountry("");
            Assert.Equal(individualResponse.Count, responseFromSearch.Count);
        }

        // case - 2: search with valid string -> return matching country
        [Fact]
        public void SearchCountry_ValidString()
        {
            List<CountryAddRequest> requests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "Bangladesh" },
                new CountryAddRequest() { CountryName = "Japan" }
            };
            List<CountryResponse>? individualResponse = new List<CountryResponse>();
            foreach (var request in requests)
            {
                individualResponse.Add(_ICountryService.AddCountry(request));
            }
            List<CountryResponse>? responseFromSearch = _ICountryService.SearchCountry("an");
            foreach(var response in responseFromSearch)
            {
                Assert.Contains(response, individualResponse);
            }
        }
        #endregion
    }
}