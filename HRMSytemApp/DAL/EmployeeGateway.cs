using HRMSytemApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HRMSytemApp.DAL
{
    public class EmployeeGateway
    {
        string con = WebConfigurationManager.ConnectionStrings["HRMApp"].ConnectionString;
        public int AddEmployee(Employee employee)
        {

            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("AddEmployee", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
            cmd.Parameters.AddWithValue("@DOB", employee.DOB);
            cmd.Parameters.AddWithValue("@Country", employee.Country);
            cmd.Parameters.AddWithValue("@Mail", employee.Mail);
            cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            cmd.Parameters.AddWithValue("@DesignationId", employee.DesignationId);
            cmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
            cmd.Parameters.AddWithValue("@Salary",Convert.ToDecimal( employee.Salary));
            cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
            cmd.Parameters.AddWithValue("@NID", employee.NID);
            cmd.Parameters.AddWithValue("@Status", employee.Status);
            cmd.Parameters.AddWithValue("@MaterialStatus", employee.MaterialStatus);

            int row = cmd.ExecuteNonQuery();
            cs.Close();
            return row;

        }
        public List<Employee> GetEmployeeByStatus(string status)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetEmployeeByStatus", cs);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@Status", status);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNo = reader["PhoneNo"].ToString(),
                    Address = reader["Address"].ToString(),
                    Salary = Convert.ToDecimal(reader["Salary"]),
                    DesignationTile = reader["DesignationTitle"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString(),
                    CompanyName=reader["CompanyName"].ToString(),
                    Status=reader["Status"].ToString()


                }


                ) ;
                

            }
            return employees;

        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetAllEmployee", cs);
           
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNo = reader["PhoneNo"].ToString(),
                    Address = reader["Address"].ToString(),
                    Salary = Convert.ToDecimal(reader["Salary"]),
                    DesignationTile = reader["DesignationTitle"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    Status = reader["Status"].ToString()


                }


                );


            }
            return employees;

        }
        public List<Employee>SearchEmployee(DateTime FromDate ,DateTime ToDate)
        {

            List<Employee> employees = new List<Employee>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("SearchEmployeeByJoiningDate", cs);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNo = reader["PhoneNo"].ToString(),
                    Address = reader["Address"].ToString(),
                    Salary = Convert.ToDecimal(reader["Salary"]),
                    JoiningDate=Convert.ToDateTime(reader["JoiningDate"].ToString()),
                    DesignationTile = reader["DesignationTitle"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString(),
                    CompanyName = reader["CompanyName"].ToString()


                }


                );


            }
            return employees;


        }
        public int Delete(int ID, string action)
        {
            int i;
            SqlConnection cs = new SqlConnection(con);

            cs.Open();
            SqlCommand com = new SqlCommand("DeleteById", cs);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", ID);
            com.Parameters.AddWithValue("@Action", action);
            i = com.ExecuteNonQuery();

            return i;
        }

    }
}