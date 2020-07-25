using System;
using System.Collections.Generic;

namespace EFDataAccess.Data
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public int? AddressId { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }

        public virtual Department Department { get; set; }
    }
}
