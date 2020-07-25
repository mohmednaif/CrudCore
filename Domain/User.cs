using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class User
    {
        public User()
        {
            Address = new Address();
            Department = new Department();
        }

        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Numeric value only")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public int? Gender { get; set; }

        public int? AddressId { get; set; }

        public int? DepartmentId { get; set; }

        public string ProfileImage { get; set; }

        public int? RoleId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Enter valid password")]
        public string Password { get; set; }

        public Address Address { get; set; }
        public Department Department { get; set; }
    }
}
