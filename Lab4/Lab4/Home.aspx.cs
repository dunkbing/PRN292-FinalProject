using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4 {
    public partial class Home : System.Web.UI.Page, ILoad {
        List<Article> articles;
        string index;
        protected void Page_Load(object sender, EventArgs e) {
            LoadData();
            LoadCurrentAccount();
        }
        public void LoadData() {
            index = Request.QueryString.Get("index");
            int i;
            try { i = index != null ? Convert.ToInt32(index) : 1; } catch (FormatException) { i = 1; }
            articles = ArticleDao.PostsPaginate(i, 4);
            postRepeater.DataSource = articles;
            postRepeater.DataBind();
            mostPopularGames.DataSource = GamesDao.MostPopularGames();
            mostPopularGames.DataBind();
        }

        public void LoadCurrentAccount() {
            Account currAcc = (Account)Session["currentAccount"];
            if (currAcc != null) {
                currentAccount.Text = currAcc.Username;
                currentAccount.NavigateUrl = "#";
                register.Text = "Logout";
                register.NavigateUrl = "Logout.aspx";
            } else {
                currentAccount.Text = "Login";
                currentAccount.NavigateUrl = "Login.aspx";
                register.Text = "Register";
                register.NavigateUrl = "Register.aspx";
            }
        }
        /*void LoadData() {
            
        }
        void LoadCurrentAccount() {
            
        }*/
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