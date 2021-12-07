using CrystalDecisions.CrystalReports.Engine;
using HRMSytemApp.DAL;
using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMSytemApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeGateway employeeGateway = new EmployeeGateway();
        DepartmentGateway departmentGateway = new DepartmentGateway();
        DesignationGateway designationGateway = new DesignationGateway();
        CompanyGateway comapnyGateway = new CompanyGateway();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = employeeGateway.GetAllEmployee();
            return View(employees);
        }
       
        //public ActionResult Index(int Id ,string status)
        //{
        //    if(status=="Active")
        //    {
        //         status = "InActive";
                
        //    }
        //    else
        //    {
        //        status = "Active";
        //    }
        //   List<Employee>employees=  employeeGateway.GetEmployeeByStatus(status);
        //    return View(employees);
        //}
        public ActionResult Create()
        {
           ViewBag.Departments= departmentGateway.GetAllDepartment();
           ViewBag.Designations= designationGateway.GetAllDesignation();
            ViewBag.Companies = comapnyGateway.GetAllCompany();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            ViewBag.Departments = departmentGateway.GetAllDepartment();
            ViewBag.Designations = designationGateway.GetAllDesignation();
            ViewBag.Companies = comapnyGateway.GetAllCompany();
          
                int row = employeeGateway.AddEmployee(employee);
                if (row > 0)
                {
                    ViewBag.Message = "Save Successfully";
                    ModelState.Clear();
                }

            
            return View();
        }
        public ActionResult Search()
        {
            
            return View();
        }
       
        [HttpPost]
        public ActionResult SearchJoiningDate(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                List<Employee> employees = employeeGateway.SearchEmployee(FromDate, ToDate);
                Session["Employees"] = employees;

                return Json(employees, JsonRequestBehavior.AllowGet);

            }
           catch(Exception ex)
            {
              return ViewBag.Error= ex.Message;
            }
        }
        public ActionResult ExportReport()
        {
            string status = "Active";
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeDetails.rpt"));
            reportDocument.SetDataSource(employeeGateway.GetEmployeeByStatus(status).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "EmployeeDetails.pdf");
            }
            catch
            {
                throw;
            }

        }
        public ActionResult JoiningExportReport()
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Path.Combine(Server.MapPath("~/Reports"), "JoiningEmployeeDetails.rpt"));
            reportDocument.SetDataSource(Session["Employees"]);
            List<Employee> employees =(List<Employee>) Session["Employees"];
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "JoiningEmployeeDetails.pdf");
            }
            catch
            {
                throw;
            }

        }
        public ActionResult Delete(int ID)
        {
            string action = "Employee";
            employeeGateway.Delete(ID, action);
            return RedirectToAction("Index");
        }
    }
}