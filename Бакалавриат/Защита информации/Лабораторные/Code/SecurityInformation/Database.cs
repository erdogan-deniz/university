using MySql.Data.MySqlClient;

namespace SecurityInformation
{
    internal class Database
    {
        readonly MySqlConnection sqlSqlConnection = new MySqlConnection("server=localhost;user=root;database=usersdatabase;password=root;");  

        public void OpenConnection()
        {
            if (sqlSqlConnection.State == System.Data.ConnectionState.Closed)
                sqlSqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (sqlSqlConnection.State == System.Data.ConnectionState.Open)
                sqlSqlConnection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return sqlSqlConnection;
        }
    }
}
