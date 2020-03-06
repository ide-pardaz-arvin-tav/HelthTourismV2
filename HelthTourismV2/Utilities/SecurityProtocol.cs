using System.Configuration;
using System.Data.SqlClient;

namespace HelthTourismV2.Utilities
{
    public class SecurityProtocol
    {
        private static string ConnectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private static SqlConnection _connection;
        private static SqlCommand _command;
        
        public static string FetchJwtProtocolKey()
        {
            try
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
                _command = new SqlCommand($"select JwtKey from TblConfig where id = 1", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return reader["JwtKey"].ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}