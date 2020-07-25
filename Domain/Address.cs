using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Address
    {
        public Address()
        {
            Country = new Country();
            State = new State();
            City = new City();

        }
        public int AddressId { get; set; }

        [Required(ErrorMessage = "House/Office No is required")]
        public string HouseOfficeNo { get; set; }

        [Required(ErrorMessage = "Street1 is required")]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Nullable<int> CountryId { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Range(1, Int32.MaxValue, ErrorMessage = "State is required")]
        public Nullable<int> StateId { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Range(1, Int32.MaxValue, ErrorMessage = "City is required")]
        public Nullable<int> CityId { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        public Nullable<int> ZipCode { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }

    }
}
