using System;
using System.Collections.Generic;

namespace EFDataAccess.Data
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
