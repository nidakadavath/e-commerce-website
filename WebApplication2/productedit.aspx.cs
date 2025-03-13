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
    public partial class productedit : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from product ";
                DataSet da = ob.fn_dataset(str);
                GridView1.DataSource = da;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            string productId = row.Cells[1].Text;

            Session["uid"] = productId;

            string query = "SELECT * FROM product WHERE product_id ='" + productId + "'";
            DataSet categoryData = ob.fn_dataset(query);
            GridView2.DataSource = categoryData;
            GridView2.DataBind();
        }
        public void bindgridview2()
        {

            string query = "SELECT * FROM product WHERE product_id ='" + Session["uid"] + "'";
            DataSet Data = ob.fn_dataset(query);
            GridView2.DataSource = Data;
            GridView2.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            bindgridview2();
        }
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            bindgridview2();
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView2.DataKeys[i].Value);
            TextBox txtproduct_description = (TextBox)GridView2.Rows[i].Cells[6].Controls[0];
            TextBox txtproduct_status = (TextBox)GridView2.Rows[i].Cells[8].Controls[0];
            TextBox txtproduct_price= (TextBox)GridView2.Rows[i].Cells[5].Controls[0];
            TextBox txtproduct_stock = (TextBox)GridView2.Rows[i].Cells[7].Controls[0];
            FileUpload fileUpload = (FileUpload)GridView2.Rows[i].FindControl("FileUpload1");
            string p = "~/product/" + fileUpload.FileName;
            fileUpload.SaveAs(MapPath(p));

            string update = "UPDATE product SET product_image='" + p + "',product_description = '"
                    + txtproduct_description.Text.Trim()
                    + "', product_status = '"
                    + txtproduct_status.Text.Trim()
                    +"',product_price='"
                    +txtproduct_price.Text.Trim()
                    +"',product_stock='"
                    +txtproduct_stock.Text.Trim()
                    + "' WHERE product_id = "
                    + getid;

            int s = ob.fn_nonquery(update);
            GridView2.EditIndex = -1;
            bindgridview2();
        }

    }
}