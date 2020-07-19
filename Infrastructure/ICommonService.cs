using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface ICommonService
    {

        User GetUserByUserNamePassword(User user);


    }
}
