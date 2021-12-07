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
    public class CompanyGateway
    {
        string con = WebConfigurationManager.ConnectionStrings["HRMApp"].ConnectionString;
        public int AddCompany(Company company)
        {
            
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("AddComapnay",cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ComapnyName", company.CompanyName);
            cmd.Parameters.AddWithValue("@Description", company.Description);
            int row=  cmd.ExecuteNonQuery();
            cs.Close();
            return row;

        }
        public List<Company> GetAllCompany()
        {
            List<Company> companies = new List<Company>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetAllCompany", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                companies.Add(new Company
                {
                    Id = Convert.ToInt32(reader["Id"]),

                    CompanyName = reader["CompanyName"].ToString(),
                    Description = reader["Description"].ToString()

                });



            }
            return companies;

        }
        public bool IsExistCompany(string companyName)
        {
            Company company = new Company();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("ExistDataCompany", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyName", companyName);
            
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.HasRows)
            {
                return true;
            }
            return false;



        }
        //Method for Updating Employee record  
        public int Update(Company company)
        {
            int i;
            SqlConnection cs = new SqlConnection(con);


                cs.Open();
                SqlCommand com = new SqlCommand("UpdateCompany", cs);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", company.Id);
                com.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            com.Parameters.AddWithValue("@Description", company.Description);
             
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