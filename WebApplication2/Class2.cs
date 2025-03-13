using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class Class2
    {
        SqlConnection con;
        public Class2()
        {
            con = new SqlConnection(@"server =LAPTOP-A7D9DENM\SQLEXPRESS; database = project1; integrated security = true");

        }

        public void fn_nonquery(SqlCommand cmd)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd.Connection = con;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}