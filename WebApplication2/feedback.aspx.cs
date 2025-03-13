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
    public partial class feedback : System.Web.UI.Page
    {
        Class2 ob = new Class2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertFeedback";
            //input parameter
            cmd.Parameters.AddWithValue("@user_id", Session["uid"]);
            cmd.Parameters.AddWithValue("@feedback_message", FeedbackTextBox.Text);
            cmd.Parameters.AddWithValue("@feedback_status", "active");
            //Output paramter
            SqlParameter sp = new SqlParameter();
            sp.DbType = DbType.Int32;
            sp.ParameterName = "@status";
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            ob.fn_nonquery(cmd);
            int outputval = Convert.ToInt32(sp.Value);
            if (outputval == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Feedback send successfully";

            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("userhome.aspx");
        }
    }
}