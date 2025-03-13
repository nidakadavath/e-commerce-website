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
    public partial class productinsert : System.Web.UI.Page
    {
        Class1 ob=new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                string str = "select category_id,category_name from category";
                DataSet ds = ob.fn_dataset(str);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "category_name";
                DropDownList1.DataValueField = "category_id";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/product/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str1 = "insert into product values (" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+TextBox4.Text+"','available')";
            int ins = ob.fn_nonquery(str1);
            if(ins==1)
            {
                Label1.Visible = true;
                Label1.Text = "inserted";
            }
        }
    }
}