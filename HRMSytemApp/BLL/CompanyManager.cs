using HRMSytemApp.DAL;
using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMSytemApp.BLL
{
    public class CompanyManager
    {
        CompanyGateway CompanyGateway = new CompanyGateway();
     
        //Company company = new Company();
        public string Save(Company company)
        {
            if (CompanyGateway.IsExistCompany(company.CompanyName))
            {
                throw new Exception("Company name already exist");
                
            }
            int row = CompanyGateway.AddCompany(company);
            if(row>0)
            {
                return "Save Sucessfully";
            }
            return "Save failed";

        }
        public List<Company> GetAllCompany()
        {
          List<Company> companies =   CompanyGateway.GetAllCompany();
            return companies;
        }
        //public void Update(Department department)
        //{
           
        //}
}
}