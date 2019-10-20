using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Net;

namespace Ashish_Google_Signing
{
    public partial class MyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleConnect.ClientId = "1079295486794-rqudf3vs0qv4kibbn06i8hl9s19b9rgb.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "nx0fD8DfNsnGvAGTAZqt2M0L";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", code);
                GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
                lblAC_ID.Text = profile.Id;
                lblName.Text = profile.DisplayName;
                lblAdd.Text = profile.Emails.Find(email => email.Type == "account").Value;
            }
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            GoogleConnect.Authorize("profile", "email");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://accounts.google.com/logout", true);

        }
    }
    public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }
        public string Gender { get; set; }
        public string ObjectType { get; set; }
    }
    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
    public class Image
    {
        public string Url { get; set; }
    }
}