using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Lab4 {
    public partial class Logout : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Account account = (Account)Session["currentAccount"];
            if (account != null) {
                Session.Remove("currentAccount");
            }
            Response.Redirect("Home.aspx");
        }
    }
}