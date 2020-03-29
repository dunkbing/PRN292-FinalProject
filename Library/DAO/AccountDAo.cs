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
            pass.Value = password;
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

        public static int Register(Account account) {
            string sql = "insert into account values (@user, @pass, @email, 0)";
            SqlParameter user = new SqlParameter("@user", SqlDbType.VarChar);
            user.Value = account.Username;
            SqlParameter pass = new SqlParameter("@pass", SqlDbType.VarChar);
            pass.Value = account.Username;
            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
            email.Value = account.Username;
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
    }
}
