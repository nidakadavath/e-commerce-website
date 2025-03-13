using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class admin : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str1 = "select max(reg_id) from login";
            string m = ob.fn_scalar(str1);
            
            int reg_id = 0;
            if(m=="")
            {
                reg_id = 1;
            }
            else
            {
                int i = Convert.ToInt32(m);

                reg_id = i++;
            }
            string str2 = "insert into admin values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "')";
            int ins = ob.fn_nonquery(str2);
            if(ins==1)
            {
                string str3 = "insert into login values(" + reg_id + ",'" + TextBox5.Text + "','" + TextBox7.Text + "','admin')";
                int ins1 = ob.fn_nonquery(str3);
            }
            Label1.Visible = true;
            Label1.Text = "registered";
            string s = Label1.Text;
            if (s == "registered")
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}