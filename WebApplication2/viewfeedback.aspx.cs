using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace WebApplication2
{
    public partial class viewfeedback : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFeedbackData();
            }
        }

        public void BindFeedbackData()
        {

            try
            {
                // Corrected SQL query
                string query = @"
                    SELECT 
                        f.feedback_id, 
                        f.user_id, 
                        u.user_name, 
                        f.feedback_message
                    FROM 
                        dbo.feedback2 f
                    INNER JOIN 
                        dbo.user1 u ON f.user_id = u.user_id
                    WHERE 
                        f.feedback_status = 'active'";

                // Fetch data using the fn_dataset method
                DataSet da = ob.fn_dataset(query);

                // Check if the DataSet contains data
                if (da != null && da.Tables.Count > 0 && da.Tables[0].Rows.Count > 0)
                {
                    // Bind the DataSet to the GridView
                    FeedbackGridView.DataSource = da;
                    FeedbackGridView.DataBind();
                }
                else
                {
                    // Display a message if no data is found
                    Response.Write("<script>alert('No active feedback found.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void FeedbackGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int user_id = Convert.ToInt32(e.CommandArgument);
            Panel1.Visible = true;
            Session["fuid"] = user_id;
            string w = "select email from user1 where user_id=" + user_id + "";
            string usermail = ob.fn_scalar(w);
            string y = "select email from admin where admin_id='" + Session["uid"] + "'";
            string admail = ob.fn_scalar(y);
            textbox1.Text = admail;
            textbox2.Text = usermail;
            Session["admail"] = admail;
        }
        protected void btnSend_Click1(object sender, EventArgs e)
        {
            string st = "select user_id from feedback2 where user_id=" + Session["fuid"] + "";
            string st1 = ob.fn_scalar(st);
            string name = "select user_name from user1 where user_id=" + st1 + "";
            SqlDataReader dr = ob.fn_reader(name);
            string usrname = "";
            while (dr.Read())
            {
                usrname = dr["user_name"].ToString();
            }
            SendEmail2("admin", textbox1.Text, "mbbm hjrl iaqr sybk", usrname, textbox2.Text, "reply", textbox3.Text);
            string up = "update feedback2 set reply_message='" + textbox3.Text + "',feedback_status='replyed' where user_id= " + Session["fuid"] + "";
            int up1 = ob.fn_nonquery(up);
            if (up1 == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Reply send successfully";
            }

        }


        public static void SendEmail2(string yourName, string yourGmailusername, string yourGmailPassword, string toName, string toEmail, string subject, string body)
        {
            string to = toEmail; //To address
            string from = yourGmailusername;
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp

            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(yourGmailusername, yourGmailPassword);

            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {

            }
        }

       

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminhome.aspx");
        }

        
        
    }
}
  




