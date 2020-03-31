using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class AccountDao {
        public static Account Login(string username, string password) {
            string sql = "select top 1 * from account where username = @user and password = @pass";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            SqlParameter pass = new SqlParameter("@pass", SqlDbType.VarChar);
            pass.Value = Account.EncryptPass(password);
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, user, pass);
            if (dt.Rows.Count > 0) {
                Account a = new Account();
                a.Username = username;
                a.Password = password;
                a.Email = dt.Rows[0]["email"].ToString();
                a.Admin = (bool)dt.Rows[0]["admin"];
                return a;
            }
            return null;
        }
        public static Account GetAccount(string username) {
            string sql = "select top 1 * from account where username = @user";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, user);
            if (dt.Rows.Count > 0) {
                Account a = new Account();
                a.Username = username;
                a.Email = dt.Rows[0]["email"].ToString();
                a.Admin = (bool)dt.Rows[0]["admin"];
                a.Avatar = dt.Rows[0]["avatar"].ToString();
                return a;
            }
            return null;
        }

        public static int Register(Account account) {
            string sql = "insert into account values (@user, @pass, @email, 0)";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = account.Username;
            SqlParameter pass = new SqlParameter("@pass", SqlDbType.VarChar);
            pass.Value = Account.EncryptPass(account.Password);
            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
            email.Value = account.Email;
            int row = Dao.ExecuteSqlWithParams(sql, user, pass, email);
            return row;
        }

        public static bool UpvoteForPost(string username, int postid) {
            string sql = "select * from postjudge where username = @user and postid = @id and upvote = 1";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            SqlParameter id = new SqlParameter("@id", postid);
            id.Value = postid;
            return Dao.GetDataTableBySqlWithParameters(sql, user, id).Rows.Count>0;
        }

        public static void Vote(string username, int postid, bool type) {
            string sql = "if not exists (select * from postjudge where username = @user and postid = @id) " +
                "begin insert into postjudge values(@id, @user, @up, @down) end " +
                "else begin update postjudge set upvote = @up, downvote = @down where username = @user and postid = @id end";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = postid;
            SqlParameter up = new SqlParameter("@up", SqlDbType.Bit);
            up.Value = type;
            SqlParameter down = new SqlParameter("@down", SqlDbType.Bit);
            down.Value = !type;
            Dao.ExecuteSqlWithParams(sql, user, id, up, down);
        }

        public static bool? Voted(string username, int postid) {
            string sql = "select upvote from postjudge where postid = @pid and username = @user";
            SqlParameter pid = new SqlParameter("@pid", SqlDbType.Int);
            pid.Value = postid;
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, pid, user);
            if (dt.Rows.Count == 0) return null;
            return (bool)dt.Rows[0]["upvote"];
        }

        public static void Comment(string username, string content, int postid) {
            string sql = "insert into comment values(@user, @content, @pid, getdate())";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            SqlParameter cont = new SqlParameter("@content", SqlDbType.VarChar);
            cont.Value = content;
            SqlParameter pid = new SqlParameter("@pid", SqlDbType.Int);
            pid.Value = postid;
            Dao.ExecuteSqlWithParams(sql, user, cont, pid);
        }

        public static void Reply(int cmtid, string content, string username) {
            string sql = "insert into reply values(@cid, @cont, @user, getdate())";
            SqlParameter cid = new SqlParameter("@cid", SqlDbType.Int);
            cid.Value = cmtid;
            SqlParameter cont = new SqlParameter("@cont", SqlDbType.VarChar);
            cont.Value = content;
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            Dao.ExecuteSqlWithParams(sql, cid, cont, user);
        }

        public static void CreatePost(string title, string content, string username, string imgurl) {
            string sql = "insert into post values(@titl, @cont, getdate(), @user, 0, @img)";
            SqlParameter titl = new SqlParameter("@titl", SqlDbType.VarChar);
            titl.Value = title;
            SqlParameter cont = new SqlParameter("@cont", SqlDbType.VarChar);
            cont.Value = content;
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            SqlParameter img = new SqlParameter("@img", SqlDbType.VarChar);
            img.Value = imgurl;
            Dao.ExecuteSqlWithParams(sql, titl, cont, user, img);
        }

        public static List<Article> GetArticlesByUsername(string username, int index, int size) {
            List<Article> articles = new List<Article>();
            string sql = "select * from post where username = @user order by datecreated desc  offset (@index-1)*@size rows  fetch next @size rows only ";
            
            SqlParameter indexParam = new SqlParameter("@index", SqlDbType.Int);
            indexParam.Value = index;
            SqlParameter sizeParam = new SqlParameter("@size", SqlDbType.Int);
            sizeParam.Value = size;
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = username;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, user, indexParam, sizeParam);
            foreach (DataRow item in dt.Rows) {
                Article a = new Article();
                a.ID = (int)item["id"];
                a.Title = item["title"].ToString();
                a.Content = item["content"].ToString();
                a.DateCreated = (DateTime)item["datecreated"];
                a.Username = item["username"].ToString();
                a.View = (int)item["view"];
                a.ImageUrl = item["imageurl"].ToString();
                articles.Add(a);
            }
            return articles;
        }
    }
}
