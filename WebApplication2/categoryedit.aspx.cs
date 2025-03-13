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
    public partial class categoryedit : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from category ";
                DataSet da = ob.fn_dataset(str);
                GridView1.DataSource = da;
                GridView1.DataBind();
            }

        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
            string categoryId = row.Cells[1].Text;

            Session["uid"] = categoryId;

            string query = "SELECT * FROM category WHERE category_id ='"+categoryId+"'";
            DataSet categoryData = ob.fn_dataset(query);
            GridView2.DataSource = categoryData;
            GridView2.DataBind();
        }
        public void bindgridview2()
        {

           


            string query = "SELECT * FROM category WHERE category_id ='" + Session["uid"] + "'";
            DataSet categoryData = ob.fn_dataset(query);
            GridView2.DataSource = categoryData;
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
            TextBox txtcategory_description = (TextBox)GridView2.Rows[i].Cells[4].Controls[0];
            TextBox txtcategory_status= (TextBox)GridView2.Rows[i].Cells[5].Controls[0];
            FileUpload fileUpload = (FileUpload)GridView2.Rows[i].FindControl("FileUpload1");
            string p = "~/category/" + fileUpload.FileName;
            fileUpload.SaveAs(MapPath(p));

            string update = "UPDATE category SET category_image='"+p+"',category_description = '"
                    + txtcategory_description.Text.Trim()
                    + "', category_status = '"
                    + txtcategory_status.Text.Trim()
                    + "' WHERE category_id = "
                    + getid;

            int s = ob.fn_nonquery(update);
            GridView2.EditIndex = -1;
            bindgridview2();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}