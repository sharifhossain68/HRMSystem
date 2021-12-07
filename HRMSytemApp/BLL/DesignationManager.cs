using HRMSytemApp.DAL;
using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMSytemApp.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public string Save(Designation designation)
        {
            if (designationGateway.IsExistDesignation(designation.DepartmentId,designation.DesignationTitle))
            {
                throw new Exception("Designation name already exist");

            }
            int row = designationGateway.AddDesignation(designation);
            if (row > 0)
            {
                return "Save Sucessfully";
            }
            return "Save failed";

        }
        public List<Designation> GetAllDesignation()
        {
            List<Designation> designations = designationGateway.GetAllDesignation();
            return designations;
        }
        public List<Designation> GetDesignation(int id)
        {
            List<Designation> designations = designationGateway.GetDesignation(id);
            return designations;
        }
        public void  Update(Designation designation)
        {
            if (designationGateway.IsExistDesignation(designation.DepartmentId, designation.DesignationTitle))
            {
                throw new Exception("Designation name already exist");

            }
            designationGateway.Update(designation);

        }
    }
}