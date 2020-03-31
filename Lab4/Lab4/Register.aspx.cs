using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Lab4 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                Account account = new Account();
                account.Username = username.Text;
                account.Password = password.Text;
                account.Email = email.Text;
                account.Admin = false;
                try {
                    int row = AccountDao.Register(account);
                    notify.Text = row > 0 ? "register successfully" : "failed to register";
                } catch (SqlException ex) {
                    notify.Text = ex.Message;
                }
                
            }
        }
    }
}