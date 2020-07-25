using System;
using System.Collections.Generic;

namespace EFDataAccess.Data
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string HouseOfficeNo { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? ZipCode { get; set; }
    }
}
