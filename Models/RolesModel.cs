using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffManagementSystem.Models
{
    public class RolesModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleTbName { get; set; }
        [Display(Name ="Description")]
        public string RoleTbDescription { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}