using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDInterfaces.DTOs
{
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(CountryResponse)) return false;
            CountryResponse other = (CountryResponse)obj;
            return other.CountryId == this.CountryId && other.CountryName == this.CountryName;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
            };
        }
    }
}
