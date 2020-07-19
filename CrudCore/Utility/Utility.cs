using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCore.Utility
{
    public class Utility
    {

    }
    public enum Role
    {
        Admin = 1,
        HRManager = 2,
        FinanceManager = 3,
        ITManager = 4,
    }


    public static class RoleName
    {
        public const string Admin = "Admin";
        public const string HRManager = "HRManager";
        public const string FinanceManager = "FinanceManager";
        public const string ITManager = "ITManager";
    }




}
