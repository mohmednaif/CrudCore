using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City
    {
        public int CityId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string CityName { get; set; }
    }


}
