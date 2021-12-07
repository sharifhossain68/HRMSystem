using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HRMSytemApp.DAL
{
    public class ConnectionGateway
    {
        string con = WebConfigurationManager.ConnectionStrings["HRMApp"].ConnectionString;
       
        public void GetConection()
        {
            SqlConnection cs = new SqlConnection(con);
            cs.Open();


        }




    }
}