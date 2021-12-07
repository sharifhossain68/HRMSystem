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
    public class DesignationGateway
    {
        string con = WebConfigurationManager.ConnectionStrings["HRMApp"].ConnectionString;
        public int AddDesignation(Designation designation)
        {

            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("AddDesignation", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DesignationTitle", designation.DesignationTitle);
            cmd.Parameters.AddWithValue("@DepartmentId", designation.DepartmentId);
            cmd.Parameters.AddWithValue("@Description", designation.Description);
            int row = cmd.ExecuteNonQuery();
            cs.Close();
            return row;

        }
        public bool IsExistDesignation(int id,string designation )
        {
            
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("ExistDataDesignation", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DesignationTitle", designation);
            cmd.Parameters.AddWithValue("@DepartmentId", id);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows)
            {
                return true;
            }
            return false;
        }
        public List<Designation> GetAllDesignation()
        {
            List<Designation> designations = new List<Designation>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetAllDesignation", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                designations.Add(new Designation
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DesignationTitle = reader["DesignationTitle"].ToString(),
                    //Description = reader["Description"].ToString()
                    DepartmentName = reader["DepartmentName"].ToString()

                });



            }
            return designations;




        }
        public List<Designation> GetDesignation(int id)
        {
            List<Designation> designations = new List<Designation>();
            SqlConnection cs = new SqlConnection(con);
            cs.Open();

            SqlCommand cmd = new SqlCommand("GetDesignationByDepartmentId", cs);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                designations.Add(new Designation
                {
                    Id = Convert.ToInt32(reader["Id"]),

                    DesignationTitle = reader["DesignationTitle"].ToString(),


                });


            }
            return designations;
        }
        //Method for Updating Employee record  
        public int Update(Designation designation)
        {
            int i;
            SqlConnection cs = new SqlConnection(con);


            cs.Open();
            SqlCommand com = new SqlCommand("UpdateDesignation", cs);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", designation.Id);
            com.Parameters.AddWithValue("@DesignationTitle", designation.DesignationTitle);
            com.Parameters.AddWithValue("@Description", designation.Description);
            com.Parameters.AddWithValue("@DepartmentId", designation.DepartmentId);

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