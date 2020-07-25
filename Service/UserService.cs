using EFDataAccess.Data;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly DemoDBContext demoDBContext;

        public UserService(EFDataAccess.Data.DemoDBContext demoDBContext)
        {
            this.demoDBContext = demoDBContext;
        }


        public Domain.User GetUserByUserNamePassword(Domain.User userModel)
        {
            Domain.User user = demoDBContext.User
                .Where(x => x.Username == userModel.Username && x.Password == userModel.Password)
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
                    ProfileImage = x.ProfileImage
                })
                .FirstOrDefault();

            return user;
        }

        public int SaveUser(Domain.User userModel)
        {
            User efUser = new User();
            if (userModel.UserId == 0)
            {
                demoDBContext.User.Add(efUser);
            }
            else
            {
                efUser = demoDBContext.User.Where(x => x.UserId == efUser.UserId).FirstOrDefault();
            }

            efUser.FirstName = userModel.FirstName;
            efUser.LastName = userModel.LastName;
            efUser.Email = userModel.Email;
            efUser.Phone = userModel.Phone;
            efUser.BirthDate = userModel.BirthDate;
            efUser.Gender = userModel.Gender;
            efUser.AddressId = userModel.AddressId;
            efUser.DepartmentId = userModel.DepartmentId;
            efUser.RoleId = userModel.RoleId;
            efUser.Username = userModel.Username;
            efUser.Password = userModel.Password;
            efUser.ProfileImage = userModel.ProfileImage;

            demoDBContext.SaveChanges();

            return efUser.UserId;
        }

        public List<Domain.User> GetUserList(int pageSize, int skip, string sortColumn, string sortColumnDir, string searchValue)
        {
            List<Domain.User> userList = new List<Domain.User>();

            var query = (from User u in demoDBContext.User
                         join Address a in demoDBContext.Address on u.AddressId equals a.AddressId into result
                         from a in result.DefaultIfEmpty()
                         select new Domain.User()
                         {
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Email = u.Email,
                             Phone = u.Phone,
                             BirthDate = u.BirthDate,
                             Gender = u.Gender,
                             AddressId = u.AddressId,
                             DepartmentId = u.DepartmentId,
                             RoleId = u.RoleId,
                             Username = u.Username,
                             Password = u.Password,
                             ProfileImage = u.ProfileImage,

                             Address = new Domain.Address()
                             {
                                 AddressId = a.AddressId,
                                 CityId = a.CityId,
                                 CountryId = a.CountryId,
                                 HouseOfficeNo = a.HouseOfficeNo,
                                 StateId = a.StateId,
                                 Street1 = a.Street1,
                                 Street2 = a.Street2,
                                 ZipCode = a.ZipCode
                             }
                         }).AsQueryable();



            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    query = query.OrderBy(sortColumn + " " + sortColumnDir);
            //}
            if (!string.IsNullOrEmpty(searchValue))
            {
                //query = query.Where(m => m.FirstName == searchValue);
                query = query.Where(m => m.FirstName.Contains(searchValue));
            }

            if (pageSize != -1)
                userList = query.Skip(skip).Take(pageSize).ToList();
            else
                userList = query.ToList();

            return userList;
        }

        public int GetUserCount(string searchValue)
        {
            int count = 0;
            var query = (from User u in demoDBContext.User
                         join Address a in demoDBContext.Address on u.AddressId equals a.AddressId
                         select new Domain.User()
                         {
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             Email = u.Email,
                             Phone = u.Phone,
                             BirthDate = u.BirthDate,
                             Gender = u.Gender,
                             AddressId = u.AddressId,
                             DepartmentId = u.DepartmentId,
                             RoleId = u.RoleId,
                             Username = u.Username,
                             Password = u.Password,
                             ProfileImage = u.ProfileImage,

                             Address = new Domain.Address()
                             {
                                 AddressId = a.AddressId,
                                 CityId = a.CityId,
                                 CountryId = a.CountryId,
                                 HouseOfficeNo = a.HouseOfficeNo,
                                 StateId = a.StateId,
                                 Street1 = a.Street1,
                                 Street2 = a.Street2,
                                 ZipCode = a.ZipCode
                             }
                         }).AsQueryable();


            if (!string.IsNullOrEmpty(searchValue))
            {
                //query = query.Where(m => m.FirstName == searchValue);
                query = query.Where(m => m.FirstName.Contains(searchValue));
            }
            count = query.Count();
            return count;
        }

        public Domain.User GetUserById(int userId)
        {
            Domain.User user = new Domain.User();
            user = (from User u in demoDBContext.User
                    join Address a in demoDBContext.Address on u.AddressId equals a.AddressId
                    where u.UserId == userId
                    select new Domain.User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Phone = u.Phone,
                        BirthDate = u.BirthDate,
                        Gender = u.Gender,
                        AddressId = u.AddressId,
                        DepartmentId = u.DepartmentId,
                        RoleId = u.RoleId,
                        Username = u.Username,
                        Password = u.Password,
                        ProfileImage = u.ProfileImage,

                        Address = new Domain.Address()
                        {
                            AddressId = a.AddressId,
                            CityId = a.CityId,
                            CountryId = a.CountryId,
                            HouseOfficeNo = a.HouseOfficeNo,
                            StateId = a.StateId,
                            Street1 = a.Street1,
                            Street2 = a.Street2,
                            ZipCode = a.ZipCode
                        }
                    }).FirstOrDefault();

            return user;
        }

        public bool DeleteUserById(int userId)
        {
            var user = demoDBContext.User.Where(x => x.UserId == userId).FirstOrDefault();
            var address = demoDBContext.Address.Where(x => x.AddressId == user.AddressId).FirstOrDefault();
            demoDBContext.Address.Remove(address);
            demoDBContext.User.Remove(user);
            demoDBContext.SaveChanges();
            return true;
        }


    }




}
