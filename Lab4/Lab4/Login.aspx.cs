using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Lab4 {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void login_Click(object sender, EventArgs e) {
            Account account = AccountDao.Login(username.Text, password.Text);
            if(account != null) {
                Session["currentAccount"] = account;
                Response.Redirect("Home.aspx");
            } else {
                error.Text = "username or password not correct";
            }
        }
    }
}