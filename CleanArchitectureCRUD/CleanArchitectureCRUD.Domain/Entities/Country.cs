using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureCRUD.Domain.Entities
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
