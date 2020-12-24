using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionSql
    {
        protected SqlConnection getConnection()
        {
            return new SqlConnection(
      "Server=(local); DataBase=BikeStore; integrated security=true"
      );
        }
    }
}
