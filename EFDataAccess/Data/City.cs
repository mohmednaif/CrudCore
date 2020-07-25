using System;
using System.Collections.Generic;

namespace EFDataAccess.Data
{
    public partial class City
    {
        public int CityId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string CityName { get; set; }
    }
}
