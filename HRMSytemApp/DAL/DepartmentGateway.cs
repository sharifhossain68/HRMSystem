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
    public class DepartmentGateway
    {
        string con = WebConfigurationManager.ConnectionStrings["HRMApp"].ConnectionString;
        public int AddDepartment(Department department)
        {

            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("AddDepartment", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            cmd.Parameters.AddWithValue("@CompanyId", department.CompanyId);
            cmd.Parameters.AddWithValue("@Description", department.Description);
            int row = cmd.ExecuteNonQuery();
            cs.Close();
            return row;

        }

        public bool IsExistDepartment(int id, string departmentName)
        {

            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("ExistDataDepartmentByName", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
            cmd.Parameters.AddWithValue("@CompanyId", id);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows)
            {
                return true;
            }
            return false;
        }
        public List<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetAllDepartment", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
            {
                departments.Add(new Department
                {
                    DepartmentId = Convert.ToInt32(reader["Id"]),

                    DepartmentName = reader["DepartmentName"].ToString(),
                    //Description = reader["Description"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),

                }) ; 


                
            }
            return departments;




        }
        public List<Department>GetDepartments(int id)
        {
            List<Department> departments = new List<Department>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetDeparmentByCompanyId", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                departments.Add(new Department
                {
                    DepartmentId = Convert.ToInt32(reader["Id"]),

                    DepartmentName = reader["DepartmentName"].ToString(),


                });

          
            }
            return departments;
        }

        //Method for Updating Employee record  
        public int Update(Department department)
        {
            int i;
            SqlConnection cs = new SqlConnection(con);


            cs.Open();
            SqlCommand com = new SqlCommand("UpdateDepartment", cs);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", department.DepartmentId);
            com.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            com.Parameters.AddWithValue("@Description", department.Description);
            com.Parameters.AddWithValue("@CompanyId", department.CompanyId);

            //com.Parameters.AddWithValue("@Action", "Company");
            i = com.ExecuteNonQuery();

            return i;
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