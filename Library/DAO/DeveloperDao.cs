using Library.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class DeveloperDao {
        public static List<Developer> GetDevelopers(int index, int size) {
            List<Developer> developers = new List<Developer>();
            string sql = "select * from developer " +
                        "order by id offset (@index-1)*@size rows fetch next @size rows only";
            SqlParameter param1 = new SqlParameter("@index", SqlDbType.Int);
            param1.Value = index;
            SqlParameter param2 = new SqlParameter("@size", SqlDbType.Int);
            param2.Value = size;
            DataTable dt = Dao.GetDataTableBySqlWithParameters(sql, param1, param2);
            foreach (DataRow item in dt.Rows) {
                Developer d = new Developer();
                d.ID = Convert.ToInt32(item["id"]);
                d.Name = item["name"].ToString();
                d.Notes = item["notes"].ToString();
                d.City = item["city"].ToString();
                d.Country = item["country"].ToString();
                d.Establish = Convert.ToInt32(item["establish"]);
                developers.Add(d);
            }
            return developers;
        }

        public static int Insert(Developer d) {
            string sql = "insert into developer values(@name, @notes, @city, @country, @establish)";
            SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
            param1.Value = d.Name;
            SqlParameter param2 = new SqlParameter("@notes", SqlDbType.VarChar);
            param2.Value = d.Notes;
            SqlParameter param3 = new SqlParameter("@city", SqlDbType.VarChar);
            param3.Value = d.City;
            SqlParameter param4 = new SqlParameter("@country", SqlDbType.VarChar);
            param4.Value = d.Country;
            SqlParameter param5 = new SqlParameter("@establish", SqlDbType.Int);
            param5.Value = d.Establish;
            return Dao.ExecuteSqlWithParams(sql, param1, param2, param3, param4, param5);
        }
        public static int Total() {
            string sql = "select count(*) from developer";
            SqlCommand command = new SqlCommand(sql, Dao.GetConnection());
            command.Connection.Open();
            int total = (int)command.ExecuteScalar();
            command.Connection.Close();
            return total;
        }

        public static int Update(Developer d) {
            string sql = "update developer set name = @name, notes = @notes, city = @city, country = @country, establish = @establish " +
                "where id = @id";
            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
            name.Value = d.Name;
            SqlParameter notes = new SqlParameter("@notes", SqlDbType.VarChar);
            notes.Value = d.Notes;
            SqlParameter city = new SqlParameter("@city", SqlDbType.VarChar);
            city.Value = d.City;
            SqlParameter country = new SqlParameter("@country", SqlDbType.VarChar);
            country.Value = d.Country;
            SqlParameter establish = new SqlParameter("@establish", SqlDbType.Int);
            establish.Value = d.Establish;
            SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
            id.Value = d.ID;
            return Dao.ExecuteSqlWithParams(sql, name, notes, city, country, establish, id);
        }
    }
}
