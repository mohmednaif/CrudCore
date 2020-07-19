using Domain;
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
                       Address = x.Address,
                       DepartmentId = x.DepartmentId,
                       RoleId = x.RoleId,
                       Username = x.Username,
                       Password = x.Password,
                   })
                   .FirstOrDefault();
            }
            catch (Exception ex)
            {

            }

            return User;

        }



    }




}
