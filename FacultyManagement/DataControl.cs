using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Group6_SE1322
{
    class DataControl
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=localhost;Initial Catalog=FacultyManagement;Integrated Security=True; uid=sa; pwd=7598");
        public void connection()
        {
            sqlConnection.Open();
        }
        public void closeConnection()
        {
            sqlConnection.Close();
        }
        public DataTable createTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, sqlConnection);
            ds.Fill(dt);
            return (dt);
        }
        public void add(string id, string name)
        {
            string sql = "Insert into Data values ('" + id + "', '" + name + "')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public void edit(string id, string name)
        {
            string sql = "Update Data set name='" + name + "'where id='" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
        public void delete(string id, string name)
        {
            string sql = "Delete from Data where id= '" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
