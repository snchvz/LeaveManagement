using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    //VM view model
    public class LeaveTypeVM
    {
        public int id { get; set; } 

        [Display(Name="Leave Type")]
        [Required]
        public string Name { get; set; } 

        //NOTE** make DateCreated nullable, otherwise the Required attribute from Name will make Date Created Required as well
        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }

}
