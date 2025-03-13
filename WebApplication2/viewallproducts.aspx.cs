using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebApplication2
{
    public partial class viewallproducts : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from product where category_id='" + Session["categoryid"] + "' and product_status='available'";
                DataSet da = ob.fn_dataset(str);
                DataList1.DataSource = da;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);


            Session["productid"] = productId;

            Response.Redirect("viewproduct.aspx");
        }
    }
}