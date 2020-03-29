using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class CommentDao {
        public static List<Comment> GetComments(int pid) {
            List<Comment> comments = new List<Comment>();
            string sql = "select * from Comment, Account where Comment.username = Account.username and postid = @postid";
            SqlParameter postid = new SqlParameter("@postid", SqlDbType.Int);
            postid.Value = pid;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, postid);
            foreach(DataRow row in dt.Rows) {
                Comment c = new Comment();
                c.ID = (int)row["id"];
                c.Username = row["username"].ToString();
                c.Content = row["content"].ToString();
                c.PostID = pid;
                c.Time = (DateTime)row["time"];
                c.Replies = new List<Reply>();
                foreach (DataRow item in GetReplyByCmtID(c.ID).Rows) {
                    Reply r = new Reply();
                    r.ID = (int)item["id"];
                    r.CommentID = c.ID;
                    r.Content = item["content"].ToString();
                    r.Username = item["username"].ToString();
                    r.Time = (DateTime)item["time"];
                    c.Replies.Add(r);
                }
                comments.Add(c);
            }
            return comments;
        }

        public static DataTable GetReplyByCmtID(int cid) {
            string sql = "select * from reply where commentid = @cmtid";
            SqlParameter cmtid = new SqlParameter("@cmtid", SqlDbType.Int);
            cmtid.Value = cid;
            return Dao.GetDataTableBySqlWithParameters(sql, cmtid);
        }
    }
}
