using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DynamicWebPage_MasterPage
{
    public partial class InsertNewContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LblMsg.Visible = false;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = true;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContentDBConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = "insert into Articles values (@id, @content, @publishDate)",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", int.Parse(TxtId.Text));
                cmd.Parameters.AddWithValue("@content", TxtCnt.Text);
                cmd.Parameters.AddWithValue("@publishDate", DateTime.Parse(TxtDt.Text));               

                con.Open();
                cmd.ExecuteNonQuery();

                LblMsg.Text = "Registration Success";

            }
            catch (Exception ex)
            {
                LblMsg.Text = "Error" + ex.Message;
            }
        }
    }
}