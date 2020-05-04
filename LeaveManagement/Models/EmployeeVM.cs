using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class EmployeeVM
    {
        //NOTE** the fields must match EXACTLY with the Database fields

        //NOTE** TKey maps to string!!
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EEID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
    }
}
