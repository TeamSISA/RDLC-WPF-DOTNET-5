using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class CustomersList : ConnectionSql
    {
        public DataTable getCustomersSP()
        {
            using (var connection = getConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"getCustomers";
                    command.CommandType = CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    reader.Dispose();

                    return table;
                }
            }


        }
    }
}
