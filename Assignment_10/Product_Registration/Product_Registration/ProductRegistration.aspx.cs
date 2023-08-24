using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Registration
{
    public partial class ProductRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LblInfo.Visible = false;
            }
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LblInfo.Visible=true;
            LblInfo.Text = "Product Successfully Registered";
            LblInfo.Text += "<br>Product Name: " + TxtName.Text;
            LblInfo.Text += "<br>Product Category: " + DdlCategory.Text;
            LblInfo.Text += "<br>Product Price: " + TxtPrice.Text;
            LblInfo.Text += "<br>Product Description: " + TxtDesc.Text;
            LblInfo.Text += "<br>Product Release Date: " + CalRD.SelectedDate;

        }
    }
}