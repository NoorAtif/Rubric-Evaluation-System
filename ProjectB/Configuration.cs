using System;
using System.Data.SqlClient;
namespace CRUD_Opeartions
{
    class Configuration
    {
        String ConnectionStr = @"Data Source= DESKTOP-F7ONIN3;Initial Catalog= ProjectB ;Integrated Security=True";
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}