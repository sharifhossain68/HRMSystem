using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMSytemApp.Models
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Designation Title")]
        public string DesignationTitle { get; set; }
        [Required]
        [Display(Name = "Department ")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Description { get; set; }

    }
}