using HRMSytemApp.DAL;
using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMSytemApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public string Save(Department department)
        {
            if (departmentGateway.IsExistDepartment(department.CompanyId,department.DepartmentName))
            {
                throw new Exception("Department name already exist");

            }
            int row = departmentGateway.AddDepartment(department);
            if (row > 0)
            {
                return "Save Sucessfully";
            }
            return "Save failed";

        }
        public List<Department> GetAllDepartment()
        {
            List<Department> departments = departmentGateway.GetAllDepartment();
            return departments;
        }
        public List<Department> GetDepartments(int id)
        {
            List<Department> departments = departmentGateway.GetDepartments(id);
            return departments;
        }
        public void Update(Department department)
        {
            if (departmentGateway.IsExistDepartment(department.CompanyId, department.DepartmentName))
            {
                throw new Exception("Department name already exist");

            }
            departmentGateway.Update(department);
        }
    }
}