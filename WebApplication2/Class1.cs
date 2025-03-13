using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class Class1
    {
        SqlConnection con;
        SqlCommand cmd;


        public Class1()
        {
            con = new SqlConnection(@"server=LAPTOP-A7D9DENM\SQLEXPRESS;database=project1;integrated security=true");
        }

        public int fn_nonquery(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public string fn_scalar(string scalar)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(scalar, con);
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;
        }

        public SqlDataReader fn_reader(string reader)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(reader, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;

        }

        public DataSet fn_dataset(string dataset)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(dataset, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable fn_dataTable(string data)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(data, con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }


    }
    
}