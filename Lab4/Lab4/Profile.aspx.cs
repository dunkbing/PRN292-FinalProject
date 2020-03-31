using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Lab4 {
    public partial class Profile : System.Web.UI.Page, ILoad {
        public string username;
        public Account a;
        string index;
        List<Article> articles;

        public void LoadCurrentAccount() {
            username = Request.QueryString.Get("username");
            a = AccountDao.GetAccount(username);
        }

        public void LoadData() {
            index = Request.QueryString.Get("index");
            int i;
            try { i = index != null ? Convert.ToInt32(index) : 1; } catch (FormatException) { i = 1; }
            articles = AccountDao.GetArticlesByUsername(username, 1, 4);
            postRepeater.DataSource = articles;
            postRepeater.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e) {
            LoadCurrentAccount();
            LoadData();
        }

        public String HyperLink(string label, string href) {
            return $"<a href=\"{href}\" class=\"page-link\"> {label} </a>";
        }
        public string pager(int pagecount) {
            int pageindex;
            try {
                index = Request.QueryString.Get("index");
                pageindex = index != null ? Convert.ToInt32(index) : 1;
            } catch (FormatException) { pageindex = 1; }
            String result = "";
            if (pageindex > 3) {
                result += HyperLink("First", "Home.aspx?index=" + 1);
            }
            for (int i = 2; i > 0; i--) {
                if (pageindex - i > 0) {
                    result += HyperLink("" + (pageindex - i), "Home.aspx?index=" + (pageindex - i));
                }
            }
            result += "<a class=\"page-link disabled\">" + pageindex + "</a>";
            for (int i = 1; i <= 2; i++) {
                if (pageindex + i <= pagecount) {
                    result += HyperLink("" + (pageindex + i), "Home.aspx?index=" + (pageindex + i));
                }
            }
            if (pageindex + 2 < pagecount - 1) {
                result += HyperLink("Last", "Home.aspx?index=" + pagecount);
            }
            return result;
        }
    }
}