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
    public partial class viewcart : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }

        }
        public void bindgrid()
        {
            string str = "select * from cart where user_id='" + Session["uid"] + "'";
            DataSet da = ob.fn_dataset(str);
            GridView1.DataSource = da;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int getid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string str1 = "delete from cart where cart_id=" + getid + "";
            int ins = ob.fn_nonquery(str1);
            bindgrid();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bindgrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bindgrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            {
                int i = e.RowIndex;
                int getid = Convert.ToInt32(GridView1.DataKeys[i].Values[0]);
                TextBox txtquantity = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
                string str3 = "select product_price from product where product_id = '" + Session["productid"] + "'";
                string price = ob.fn_scalar(str3);
                int price1 = Convert.ToInt32(price);
                int quantity = Convert.ToInt32(txtquantity.Text);
                int subtotal = price1 * quantity;
                string update = "update cart set quantity=" + quantity + ", subtotal=" + subtotal + " where cart_id=" + getid + "";
                int ins = ob.fn_nonquery(update);
                GridView1.EditIndex = -1;
                bindgrid();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "Select max(cart_id) from cart";
            string s1 = ob.fn_scalar(s);
            int s2 = Convert.ToInt32(s1);

            for (int i = 1; i <= s2; i++)
            {
                string t = "select * from cart where cart_id=" + i + " and user_id='" + Session["uid"] + "'";

               
                SqlDataReader dr = ob.fn_reader(t);
                int pid =0;
                int q = 0;
                int sb = 0;
                
                while (dr.Read())
                    {
                        
                        pid =Convert.ToInt32( dr["product_id"].ToString());
                         q = Convert.ToInt32( dr["quantity"].ToString());
                         sb = Convert.ToInt32(dr["subtotal"].ToString()) ;

                        
                    }
                string ins = "insert into order1 values (" + pid + ", " + Session["uid"]+ ", " + q + ", " + sb + ", 'ordered')";
                ob.fn_nonquery(ins);

                string del = "delete from cart where cart_id=" + i + "";
                ob.fn_nonquery(del);

            }
            string sum="select sum(subtotal) from order1 where user_id="+Session["uid"]+" and order_status='ordered'";
            string sum1 = ob.fn_scalar(sum);
            int sum2 = Convert.ToInt32(sum1);
            string ins2="insert into bill values("+Session["uid"]+","+sum2+",GETDATE())";
            ob.fn_nonquery(ins2);
            Response.Redirect("viewbill.aspx");

        }
    }
}
    



