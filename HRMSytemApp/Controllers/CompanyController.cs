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
    public class CompanyController : Controller
    {
        // GET: Company
        CompanyGateway ComapnyGateway = new CompanyGateway();
        CompanyManager companyManager = new CompanyManager();
        public ActionResult Index()
        {
           List<Company>companies= ComapnyGateway.GetAllCompany();
            return View(companies);
        }
        public ActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    string msg = companyManager.Save(company);

                    ViewBag.Message = msg;
                    ModelState.Clear();
                }
                catch(Exception ex)
                {
                  ViewBag.Exist=  ex.Message;
                }
             }            
            return View();
        }
        public ActionResult Edit(int id)
        {
            var company = ComapnyGateway.GetAllCompany().Find(x => x.Id == id);
            return View(company);
        }
        [HttpPost]
        public ActionResult Edit(Company company)
        {
            ComapnyGateway.Update(company);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            string action = "Company";
            ComapnyGateway.Delete(ID, action);
            return RedirectToAction("Index");
        }


    }
}