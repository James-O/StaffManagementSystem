using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffManagementSystem.Models
{
    public class DepartmentsModel
    {
        public int DepartmentTbId { get; set; }
        [Required(ErrorMessage ="Enter Department Name")]
        [Display(Name ="Department Name")]
        public string DeparmentTbName { get; set; }
        [Display(Name = "Department Description")]
        public string departmentTbDescription { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}