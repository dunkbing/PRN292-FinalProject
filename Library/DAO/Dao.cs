using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DAO {
    public class Dao {
        public static SqlConnection GetConnection() {
            string connectionString = ConfigurationManager.ConnectionStrings["key"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        public static DataTable GetDataTableBySql(string sql) {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataTable dataTable = new DataTable();
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            command.Connection.Close();
            return dataTable;
        }
        public static DataTable GetDataTableBySqlWithParameters(string sql, params SqlParameter[] parameters) {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            DataTable dataTable = new DataTable();
            command.Parameters.AddRange(parameters);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            command.Connection.Close();
            return dataTable;
        }

        public static int ExecuteSql(string sql) {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }
        public static int ExecuteSqlWithParams(string sql, params SqlParameter[] parameters) {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            command.Connection.Open();
            command.Parameters.AddRange(parameters);
            int k = command.ExecuteNonQuery();
            command.Connection.Close();
            return k;
        }
    }
}
