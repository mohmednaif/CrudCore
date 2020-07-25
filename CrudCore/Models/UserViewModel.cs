using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCore.Models
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            User = new User();
            UserList = new List<User>();
        }

        public User User { get; set; }
        public List<User> UserList { get; set; }




    }
}
