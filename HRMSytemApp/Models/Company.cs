using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMSytemApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        public int DepartmentId { get; set; }
        public string Description{ get; set; }
    }
}