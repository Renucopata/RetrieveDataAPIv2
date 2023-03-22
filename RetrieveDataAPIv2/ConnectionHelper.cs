using System.Data.SqlClient;

namespace RetrieveDataAPIv2
{
    public class ConnectionHelper
    {
        SqlConnection _connection;

        public ConnectionHelper(SqlConnection connecctionString)
        {
             _connection = connecctionString; 
        }

        public bool isConnected()
        {
            return (_connection.State == System.Data.ConnectionState.Open);
        }
      
    }
}
