using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IUserService
    {

        public Domain.User GetUserByUserNamePassword(Domain.User userModel);
        public int SaveUser(Domain.User userModel);
        public List<Domain.User> GetUserList(int pageSize, int skip, string sortColumn, string sortColumnDir, string searchValue);
        public int GetUserCount(string searchValue);
        public Domain.User GetUserById(int userId);
        public bool DeleteUserById(int userId);


    }
}
