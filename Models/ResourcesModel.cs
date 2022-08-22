using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffManagementSystem.Models
{
    public class ResourcesModel
    {
        [Display(Name = "Resources Name")]
        public string ResourcesTbName { get; set; }
        [Display(Name = "Resources Description")]
        public string ResourcesTbDescription { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public System.DateTime CreatedOn { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Updated On")]
        public System.DateTime UpdatedOn { get; set; }
    }
}