
using EFDataAccess.Data;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class CommonService : ICommonService
    {
        private readonly DemoDBContext demoDBContext;

        public CommonService(EFDataAccess.Data.DemoDBContext demoDBContext)
        {
            this.demoDBContext = demoDBContext;
        }

        public Domain.User GetUserByUserNamePassword(Domain.User UserModel)
        {
            Domain.User User = new Domain.User();

            try
            {
                User = demoDBContext.User
                   .Where(x => x.Username == UserModel.Username && x.Password == UserModel.Password)
                   .Select(x => new Domain.User()
                   {
                       UserId = x.UserId,
                       FirstName = x.FirstName,
                       LastName = x.LastName,
                       Email = x.Email,
                       Phone = x.Phone,
                       BirthDate = x.BirthDate,
                       Gender = x.Gender,
                       AddressId = x.AddressId,
                       DepartmentId = x.DepartmentId,
                       RoleId = x.RoleId,
                       Username = x.Username,
                       Password = x.Password,
                       ProfileImage=x.ProfileImage
                   })
                   .FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return User;

        }




        public List<Domain.Country> GetAllCountries()
        {
            List<Domain.Country> countries = new List<Domain.Country>();

            countries = demoDBContext.Country.Select(x => new Domain.Country()
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName
            }).ToList();

            return countries;
        }

        public List<Domain.State> GetStatesByCountryId(int? countryId)
        {
            List<Domain.State> states = new List<Domain.State>();
            if (countryId == null || countryId == 0)
                return states;

            states = demoDBContext.State.Where(x => x.CountryId == countryId).Select(x => new Domain.State()
            {
                CountryId = x.CountryId,
                StateId = x.StateId,
                StateName = x.StateName
            }).ToList();

            return states;
        }

        public List<Domain.City> GetCityByStateId(int? stateId)
        {
            List<Domain.City> cities = new List<Domain.City>();
            if (stateId == null || stateId == 0)
                return cities;

            cities = demoDBContext.City.Where(x => x.StateId == stateId).Select(x => new Domain.City()
            {
                CountryId = x.CountryId,
                StateId = x.StateId,
                CityId = x.CityId,
                CityName = x.CityName
            }).ToList();

            return cities;
        }

        public int SaveAddress(Domain.Address address)
        {
            Address efAddress = new Address();

            if (address.AddressId == 0)
            {
                demoDBContext.Address.Add(efAddress);
            }
            else
            {
                efAddress = demoDBContext.Address.Where(x => x.AddressId == address.AddressId).FirstOrDefault();
            }

            efAddress.CountryId = address.CountryId;
            efAddress.StateId = address.StateId;
            efAddress.CityId = address.CityId;
            efAddress.HouseOfficeNo = address.HouseOfficeNo;
            efAddress.Street1 = address.Street1;
            efAddress.Street2 = address.Street2;
            efAddress.ZipCode = address.ZipCode;

            demoDBContext.SaveChanges();

            return efAddress.AddressId;
        }

        public Domain.Address GetAddressById(int? addressId)
        {
            Domain.Address address = new Domain.Address();
            if (addressId == null || addressId == 0)
                return address;

            address = demoDBContext.Address.Where(x => x.AddressId == addressId).Select(x => new Domain.Address()
            {
                AddressId = x.AddressId,
                CountryId = x.CountryId,
                StateId = x.StateId,
                CityId = x.CityId,
                HouseOfficeNo = x.HouseOfficeNo,
                Street1 = x.Street1,
                Street2 = x.Street2,
                ZipCode = x.ZipCode
            }).FirstOrDefault();

            return address;
        }











    }




}
