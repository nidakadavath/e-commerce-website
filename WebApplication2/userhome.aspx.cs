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
    public partial class userhome : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from category where category_status='available'";
                DataSet Data = ob.fn_dataset(str);
                DataList1.DataSource = Data;
                DataList1.DataBind();
            }

        }

      
        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);

           
            Session["categoryid"] = categoryId;

            Response.Redirect("viewallproducts.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "SELECT * FROM category WHERE category_status = 'available' AND category_name LIKE '" + TextBox1.Text + "%'";
            DataSet Data = ob.fn_dataset(str);
            DataList1.DataSource = Data;
            DataList1.DataBind();

        }
    }
}