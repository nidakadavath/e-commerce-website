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
    public partial class viewproduct : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from product where product_id='" + Session["productid"] + "'";
                SqlDataReader da = ob.fn_reader(str);
                while (da.Read())
                {
                    Label1.Text = da["product_name"].ToString();
                    Label3.Text = da["product_description"].ToString();
                    Label2.Text = da["product_price"].ToString();
                    Image1.ImageUrl = da["product_image"].ToString();
                }
                da.Close();

            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string str1 = "select product_stock from product where product_id='" + Session["productid"] + "'";
            SqlDataReader dr = ob.fn_reader(str1);
            if (dr != null)
            {
                while (dr.Read())
                {
                    int stock = Convert.ToInt32(dr["product_stock"]);
                    int quantity;

                    if (int.TryParse(TextBox1.Text, out quantity))
                    {
                        if (quantity > stock)
                        {
                            Label4.Visible = true;
                            Label4.Text = "Quantity exceeds stock available.";
                        }
                        else
                        {
                            Label4.Visible = true;
                            Label4.Text = "";
                        }
                    }
                    else
                    {
                        Label4.Visible = true;
                        Label4.Text = "Invalid quantity entered.";
                    }
                }
                dr.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(TextBox1.Text);
            quantity++;
            TextBox1.Text = quantity.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(TextBox1.Text);
            quantity--;
            TextBox1.Text = quantity.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str1 = "select max(cart_id) from cart";
            string s = ob.fn_scalar(str1);

            int reg_id = 0;
            if (string.IsNullOrEmpty(s))
            {
                reg_id = 1;
            }
            else
            {
                int i = Convert.ToInt32(s);
                reg_id = i + 1; 
            }
            string str3 = "select product_price from product where product_id = '" + Session["productid"] + "'";
            string price = ob.fn_scalar(str3);
            int price1 = Convert.ToInt32(price);
            int quantity = Convert.ToInt32(TextBox1.Text);
            int subtotal = price1 * quantity;
            int productId = Convert.ToInt32(Session["productid"]);
            int userId = Convert.ToInt32(Session["uid"]);
            string str2 = "insert into cart values(" + reg_id + "," +productId + "," + userId + "," + TextBox1.Text + "," + subtotal + ")";
            int ins = ob.fn_nonquery(str2);

            Response.Redirect("viewcart.aspx");
        }
    }
}