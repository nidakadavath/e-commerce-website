using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(reg_id) from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string c = ob.fn_scalar(str);
            int i = Convert.ToInt32(c);
            if(i==1)
            {
                string str2 = "select reg_id from login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string st = ob.fn_scalar(str2);
                Session["uid"] = st;
                string str3 = "select log_type from login where reg_id='" + Session["uid"] + "'";
                string logtype = ob.fn_scalar(str3);
                if (logtype == "admin")
                {
                    Response.Redirect("adminhome.aspx");
                }
                else if(logtype=="user")
                {

                    Response.Redirect("userhome.aspx");
                  
                }
        
            }

            else
            {
                Label1.Visible = true;
                Label1.Text = "incorrect username or password";

            }
        }
    }
}