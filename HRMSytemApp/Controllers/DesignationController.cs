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
    public class DesignationController : Controller
    {
        DesignationGateway designationGateway = new DesignationGateway();
        DesignationManager DesignationManager = new DesignationManager();
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: Designation
        public ActionResult Index()
        {
           List<Designation>designations= designationGateway.GetAllDesignation();
            return View(designations);
        }
        public ActionResult Create()
        {
            ViewBag.Departments = departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Designation designation)
        {
            ViewBag.Departments = departmentManager.GetAllDepartment();
         
                try
                {
                    string msg = DesignationManager.Save(designation);
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
        public JsonResult GetDesignation(int id)
        {
            List<Designation> designations = DesignationManager.GetDesignation(id);
            return Json(designations, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = departmentManager.GetAllDepartment();
            var designation = designationGateway.GetAllDesignation().Find(x => x.Id == id);
            return View(designation);
        }
        [HttpPost]
        public ActionResult Edit(Designation designation)
        {
            ViewBag.Departments = departmentManager.GetAllDepartment();
            try
            {
                DesignationManager.Update(designation);
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
            string action = "Designation";
            designationGateway.Delete(ID, action);
            return RedirectToAction("Index");
        }
    }
}