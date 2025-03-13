using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class categoryinsert : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/category" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into category values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','available')";
            int ins = ob.fn_nonquery(str);
            if(ins==1)
            {
                Label1.Visible = true;
                Label1.Text = "inserted";

            }
        }
    }
}