using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface ICommonService
    {

        User GetUserByUserNamePassword(User user);

        List<Country> GetAllCountries();
        List<State> GetStatesByCountryId(int? countryId);
        List<City> GetCityByStateId(int? stateId);
        int SaveAddress(Address address);
        Address GetAddressById(int? addressId);



    }
}
