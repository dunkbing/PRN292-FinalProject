using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class ArticleDao {
        public static List<Article> PostsPaginate(int index, int size) {
            List<Article> articles = new List<Article>();
            string sql = "select * from post order by datecreated desc  offset (@index-1)*@size rows  fetch next @size rows only";
            SqlParameter indexParam = new SqlParameter("@index", SqlDbType.Int);
            indexParam.Value = index;
            SqlParameter sizeParam = new SqlParameter("@size", SqlDbType.Int);
            sizeParam.Value = size;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, indexParam, sizeParam);
            foreach (DataRow item in dt.Rows) {
                Article a = new Article();
                LoadDataForArticle(a, item);
                articles.Add(a);
            }
            return articles;
        }

        public static int UpdateViews(int pid) {
            string sql = "update post set [view] = [view]+1 where id = @id";
            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = pid;
            return Dao.ExecuteSqlWithParams(sql, id);
        }

        public static Article GetArticleByID(int id) {
            string sql = "select top 1 * from post where id = @id";
            SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
            idparam.Value = id;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, idparam);
            if(dt.Rows.Count > 0) {
                Article a = new Article();
                LoadDataForArticle(a, dt.Rows[0]);
                return a;
            }
            return null;
        }

        public static int Upvotes(int id) {
            string sql = "select count(*) from postjudge where postid = @id and upvote = 1";
            SqlCommand command = new SqlCommand(sql, Dao.GetConnection());
            command.Parameters.AddWithValue("@id", id);
            command.Connection.Open();
            int upvotes = (int)command.ExecuteScalar();
            command.Connection.Close();
            return upvotes;
        }
        private static void LoadDataForArticle(Article a, DataRow dt) {
            a.ID = (int)dt["id"];
            a.Title = dt["title"].ToString();
            a.Content = dt["content"].ToString();
            a.DateCreated = (DateTime)dt["datecreated"];
            a.Username = dt["username"].ToString();
            a.View = (int)dt["view"];
            a.ImageUrl = dt["imageurl"].ToString();
        }
    }
}
