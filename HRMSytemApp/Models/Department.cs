using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMSytemApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        
        public int CompanyId { get; set; }
        public string Description { get; set; }
    }
}