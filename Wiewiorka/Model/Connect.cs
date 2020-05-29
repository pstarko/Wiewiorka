using System.Data.SqlClient;

namespace Wiewiorka.Model
{
    public class Connect
    {
        public SqlConnection ConnectToDatabase()
        {
            string path = @"Data Source =localhost\SQLDEV;Initial Catalog = Wiewiorka;User Id = wiewior2; password = wiewior123";
            SqlConnection connection = new SqlConnection(path);
            connection.Open();
            return connection;
        }
    }
}