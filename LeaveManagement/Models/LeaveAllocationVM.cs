using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveAllocationVM
    {
        public int id { get; set; }

        [Required]
        public int NumberOfDays { get; set; } //Leave Days Allocated
        public DateTime DateCreated { get; set; }

        //NOTE** View Models should reference other view models only, dont reference a Data Model
        //i.e. reference EmployeeVM, not Employee
        public EmployeeVM Employee { get; set; }
        public string EmployeeId { get; set; } //use Employeeid to get Employee object

        public DetailsLeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}
