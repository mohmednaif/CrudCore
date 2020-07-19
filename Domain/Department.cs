using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Department
    {
        public Department()
        {
            User = new List<User>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<User> User { get; set; }

    }
}
