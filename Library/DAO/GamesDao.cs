using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class GamesDao {
        public static List<Games> GetGamesByDevID(int devid) {
            List<Games> games = new List<Games>();
            string sql = "select * from games where developerid = @devid";
            SqlParameter param = new SqlParameter("@devid", SqlDbType.Int);
            param.Value = devid;
            DataTable table = Dao.GetDataTableBySqlWithParameters(sql, param);
            foreach (DataRow row in table.Rows) {
                Games g = new Games();
                g.ID = (int)row["id"];
                g.Title = row["title"].ToString();
                g.DevID = (int)row["developerid"];
                g.Introduction = row["introduction"].ToString();
                g.Genre = row["genre"].ToString();
                g.Platform = row["platform"].ToString();
                g.ReleaseDate = (DateTime)row["releasedate"];
                games.Add(g);
            }
            return games;
        }

        public static List<Games> MostPopularGames() {
            List<Games> games = new List<Games>();
            string sql = "select top 5 * from games order by score desc";
            DataTable table = Dao.GetDataTableBySql(sql);
            foreach (DataRow row in table.Rows) {
                Games g = new Games();
                g.ID = (int)row["id"];
                g.Title = row["title"].ToString();
                g.DevID = (int)row["developerid"];
                g.Introduction = row["introduction"].ToString();
                g.Genre = row["genre"].ToString();
                g.Platform = row["platform"].ToString();
                g.ReleaseDate = (DateTime)row["releasedate"];
                g.Score = (double)row["score"];
                g.ImageUrl = row["imageurl"].ToString();
                games.Add(g);
            }
            return games;
        }

        public static int Update(Games g) {
            string sql = "update games set title = @title, " +
                "introduction = @intro, genre = @genre, platform = @platform, releasedate = @release " +
                "where id = @id";
            SqlParameter title = new SqlParameter("@title", SqlDbType.VarChar);
            title.Value = g.Title;
            SqlParameter intro = new SqlParameter("@intro", SqlDbType.VarChar);
            intro.Value = g.Introduction;
            SqlParameter genre = new SqlParameter("@genre", SqlDbType.VarChar);
            genre.Value = g.Genre;
            SqlParameter platform = new SqlParameter("@platform", SqlDbType.VarChar);
            platform.Value = g.Platform;
            SqlParameter release = new SqlParameter("@release", SqlDbType.DateTime);
            release.Value = g.ReleaseDate;
            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = g.ID;
            return Dao.ExecuteSqlWithParams(sql, title, intro, genre, platform, release, id);
        }

        public static int Insert(Games g) {
            string sql = "insert into games(title, developerid, introduction, genre, platform, releasedate) " +
                "values (@title, @devid, @intro, @genre, @platform, @release)";
            SqlParameter title = new SqlParameter("@title", SqlDbType.VarChar);
            title.Value = g.Title;
            SqlParameter devid = new SqlParameter("@devid", SqlDbType.Int);
            devid.Value = g.DevID;
            SqlParameter intro = new SqlParameter("@intro", SqlDbType.VarChar);
            intro.Value = g.Introduction;
            SqlParameter genre = new SqlParameter("@genre", SqlDbType.VarChar);
            genre.Value = g.Genre;
            SqlParameter platform = new SqlParameter("@platform", SqlDbType.VarChar);
            platform.Value = g.Platform;
            SqlParameter release = new SqlParameter("@release", SqlDbType.DateTime);
            release.Value = g.ReleaseDate;
            return Dao.ExecuteSqlWithParams(sql, title, devid, intro, genre, platform, release);
        }
    }
}
