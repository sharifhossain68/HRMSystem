using System;
using System.ComponentModel.DataAnnotations;

namespace HRMSytemApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }
        [Required]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Material Status")]
        public string MaterialStatus { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]

        public DateTime DOB { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone No.")]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please insert email validation  ")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        [Required]
        [Display(Name = "National ID")]
        public int NID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Designation Tile")]
        public string DesignationTile { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; }
    }
}