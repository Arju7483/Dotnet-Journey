using System;
using Entities;

namespace UnitTestServices.DTOs
{
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        
        //contains method internally use Equals method, so we need to override Equals method to compare value, not reference
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if (obj.GetType() != typeof(CountryResponse)) return false;
            CountryResponse other = (CountryResponse)obj;
            return this.CountryId == other.CountryId;
        }
    }
    // extension method to convert Country object to CountryResponse object
    public static class CountryExtensionMethod
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            CountryResponse response = new CountryResponse()
            {
                CountryId = country.CountryId
            };
            return response;
        }
    }
}
