using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SysCountries
    {
        public SysCountries()
        {
            CodCountry = new HashSet<CodCountry>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual ICollection<CodCountry> CodCountry { get; set; }
    }
}
