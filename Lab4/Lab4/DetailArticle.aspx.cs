using Library.DAO;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Lab4 {
    public partial class DetailArticle : System.Web.UI.Page, ILoad {
        int id;
        public Article article;
        Account currAcc;
        protected void Page_Load(object sender, EventArgs e) {
            LoadCurrentAccount();
            try {
                id = Convert.ToInt32(Request.QueryString.Get("id"));
                ArticleDao.UpdateViews(id);
                LoadData();
            } catch (Exception) {
                Response.Redirect("Home.aspx");
            }
        }

        public void LoadData() {
            article = ArticleDao.GetArticleByID(id);
            title.Text = article.Title;
            user.Text = "by " + article.Username + " at " + article.DateCreated;
            content.Text = article.Content;
            image.ImageUrl = article.ImageUrl;
            vote.Text = "Views: " + article.View + " | Upvotes: " + ArticleDao.Upvotes(id);
            commentGrid.DataSource = CommentDao.GetComments(id);
            commentGrid.DataBind();
        }

        public void LoadCurrentAccount() {
            currAcc = (Account)Session["currentAccount"];
            if (currAcc != null) {
                currentAccount.Text = currAcc.Username;
                currentAccount.NavigateUrl = "#";
                register.Text = "Logout";
                register.NavigateUrl = "Logout.aspx";
                if(AccountDao.UpvoteForPost(currAcc.Username, id)) {
                    EnableDownvote();
                }
            } else {
                currentAccount.Text = "Login";
                currentAccount.NavigateUrl = "Login.aspx";
                register.Text = "Register";
                register.NavigateUrl = "Register.aspx";
                upvote.Visible = false;
                downvote.Visible = false;
                comment.Visible = false;
                submitcmt.Visible = false;
            }
        }

        protected void upvote_Click(object sender, EventArgs e) {
            AccountDao.Vote(currAcc.Username, id, true);
            LoadData();
            EnableDownvote();
        }

        protected void downvote_Click(object sender, EventArgs e) {
            AccountDao.Vote(currAcc.Username, id, false);
            LoadData();
            EnableUpvote();
        }

        private void EnableUpvote() {
            downvote.CssClass = "btn btn-secondary mb-1";
            downvote.Enabled = false;
            upvote.CssClass = "btn btn-primary mb-1";
            upvote.Enabled = true;
        }

        private void EnableDownvote() {
            upvote.CssClass = "btn btn-secondary mb-1";
            upvote.Enabled = false;
            downvote.CssClass = "btn btn-primary mb-1";
            downvote.Enabled = true;
        }

        protected void submitcmt_Click(object sender, EventArgs e) {
            if(!comment.Text.Equals(string.Empty)) AccountDao.Comment(currAcc.Username, comment.Text, id);
            LoadData();
        }

        protected void btnReply_Click(object sender, EventArgs e) {
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            Label cmtIdLb = (Label)row.FindControl("cmtIdLb");
            TextBox replyContent = (TextBox)row.FindControl("replyTb");
            if(!replyContent.Text.Equals(string.Empty)) AccountDao.Reply(Convert.ToInt32(cmtIdLb.Text), replyContent.Text, currAcc.Username);
            LoadData();
        }

        protected void linkBtnReply_Click(object sender, EventArgs e) {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            Label cmtIdLb = (Label)row.FindControl("cmtIdLb");
            TextBox replyContent = (TextBox)row.FindControl("replyTb");
            if (!replyContent.Text.Equals(string.Empty)) 
                AccountDao.Reply(Convert.ToInt32(cmtIdLb.Text), replyContent.Text, currAcc.Username);
            //LoadData();
        }
    }
}