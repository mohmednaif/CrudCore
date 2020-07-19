using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User
    {
        public User()
        {
            Department = new Department();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Department Department { get; set; }
    }
}
