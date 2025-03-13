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
    public partial class viewbill : System.Web.UI.Page
    {
        private const string V = "";
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = @"
                     SELECT 
                     dbo.user1.user_name, 
                     dbo.user1.address, 
                     dbo.user1.phone, 
                     dbo.user1.email, 
                     dbo.user1.pincode, 
                     dbo.product.product_name, 
                     dbo.product.product_image, 
                     dbo.order1.quantity, 
                     dbo.order1.subtotal
                     FROM 
                     dbo.user1
                     INNER JOIN dbo.order1 ON dbo.user1.user_id = dbo.order1.user_id
                     INNER JOIN dbo.product ON dbo.order1.product_id = dbo.product.product_id
                     WHERE 
                     dbo.user1.user_id = " + Convert.ToInt32(Session["uid"]);


            SqlDataReader da = ob.fn_reader(query);

            if (da != null)
            {
                while (da.Read())
                {
                    Label6.Text = da["user_name"].ToString();
                    Label7.Text = da["address"].ToString();
                    Label8.Text = da["phone"].ToString();
                    Label9.Text = da["email"].ToString();
                    Label10.Text = da["pincode"].ToString();

                }

                da.Close(); // Ensure the reader is closed
            }
            else
            {
                // Handle cases where no data is returned
                Label6.Text = "No data found.";
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
            }
            DataSet ds = ob.fn_dataset(query);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            string sum = "SELECT SUM(subtotal) FROM order1 WHERE user_id = " + Convert.ToInt32(Session["uid"]) + " AND order_status = 'ordered'";

            string sum1 = ob.fn_scalar(sum);
            Label11.Text = sum1;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = "insert into accound1 values(" + TextBox2.Text + "," + Session["uid"] + ",'" + TextBox1.Text + "'," + TextBox3.Text + ")";
            int i = ob.fn_nonquery(str);

            Panel3.Visible = true;


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            accountReference1.ServiceClient ob1 = new accountReference1.ServiceClient();
            string accno = TextBox4.Text;

            // Fetch grand total from the database (without parameters)
            string grandt = "SELECT grand_total FROM bill WHERE user_id = '" + Session["uid"] + "'";
            double gt = Convert.ToDouble(ob.fn_scalar(grandt));

            // Validate account number
            if (string.IsNullOrEmpty(accno))
            {
                Label13.Visible = true;
                Label13.Text = "Error: Account number is missing.";
                return;
            }


            // Ensure grand total is positive
            if (gt <= 0 || double.IsNaN(gt) || double.IsInfinity(gt))
            {
                Label13.Visible = true;
                Label13.Text = "Error: Invalid grand total (must be positive).";
                return;
            }

            // Fetch current balance
            double bal;
            if (!double.TryParse(ob1.balcheck(accno), out bal))
            {
                Label13.Visible = true;
                Label13.Text = "Error: Invalid balance returned from the service.";
                return;
            }

            // Check if balance is sufficient
            if (bal >= gt)
            {
                // Calculate new balance
                double newBalance = bal - gt;
                try
                {
                    int updateResult = ob1.balupd(accno, newBalance);
                    if (updateResult == 1)
                    {
                        Label13.Visible = true;
                        Label13.Text = "Balance updated successfully.";
                    }
                    else
                    {
                        Label13.Visible = true;
                        Label13.Text = "Error: Failed to update balance.";
                    }
                }
                catch (Exception ex)
                {
                    Label13.Visible = true;
                    Label13.Text = "Error: " + ex.Message;
                }


                string SEL1 = "SELECT product_id, quantity FROM order1 WHERE user_id=" + Session["uid"] + " AND order_status='ordered'";
                SqlDataReader dr = ob.fn_reader(SEL1);

                List<int> pid = new List<int>();
                List<int> qty = new List<int>();

                while (dr.Read())
                {
                    pid.Add(Convert.ToInt32(dr["product_id"]));
                    qty.Add(Convert.ToInt32(dr["quantity"]));
                }
                dr.Close();

                // Update stock for each product
                for (int k = 0; k < pid.Count; k++)
                {
                    string selp = "SELECT product_stock FROM product WHERE product_id=" + pid[k];
                    int stock = Convert.ToInt32(ob.fn_scalar(selp));

                    int balst = stock - qty[k];
                    string upst = "UPDATE product SET product_stock=" + balst + " WHERE product_id=" + pid[k];
                    ob.fn_nonquery(upst);
                }

                // Update order status to 'paid'
                string upd = "UPDATE order1 SET order_status='paid' WHERE user_id=" + Session["uid"] + " AND order_status='ordered'";
                int s=ob.fn_nonquery(upd);
                if(s==1)
                {
                    Response.Redirect("thankss.aspx");
                }

            }
            else
            {
                Label13.Visible = true;
                Label13.Text = "Balance update failed.";
            }
        }
    }
}
            
         
            
        
    

    

    
