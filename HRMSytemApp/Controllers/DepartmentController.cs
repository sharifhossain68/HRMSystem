using HRMSytemApp.BLL;
using HRMSytemApp.DAL;
using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMSytemApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentGateway departmentGateway = new DepartmentGateway();
        CompanyManager companyManager = new CompanyManager();
        DepartmentManager departmentManager = new DepartmentManager();


        public ActionResult Index()
        {
           List<Department>departments= departmentGateway.GetAllDepartment();
            return View(departments);
        }
        public ActionResult Create()
        {
            ViewBag.Companies = companyManager.GetAllCompany();
            return View();
          
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            ViewBag.Companies = companyManager.GetAllCompany();
        
               
                try
                {
                    string msg = departmentManager.Save(department);

                    ViewBag.Message = msg;
                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ViewBag.Exist = ex.Message;
                }
            
            return View();
        }
        [HttpPost]
        public JsonResult GetDepartment(int id)
        {
            List<Department>departments= departmentManager.GetDepartments(id);
            return Json(departments,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Companies = companyManager.GetAllCompany();
            var department = departmentGateway.GetAllDepartment().Find(x => x.DepartmentId == id);
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            ViewBag.Companies = companyManager.GetAllCompany();
            try
            {
               
                departmentGateway.Update(department);
                return RedirectToAction("Index");
            }
          
              catch (Exception ex)
            {
                ViewBag.Exist = ex.Message;
            }
            return View();
        }
        public ActionResult Delete(int ID)
        {
            string action = "Department";
            departmentGateway.Delete(ID, action);
            return RedirectToAction("Index");
        }

    }
}