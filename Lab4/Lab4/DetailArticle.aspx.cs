﻿using Library.DAO;
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
            try {
                id = Convert.ToInt32(Request.QueryString.Get("id"));
                ArticleDao.UpdateViews(id);
                LoadCurrentAccount();
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

        }
    }
}