
using System.Data.SqlClient;

namespace ProductBoundedContext.Data.Context
{
    public class ProductSqlDataContext
    {
        public SqlConnection Connection { get; }

        public ProductSqlDataContext(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        
    }
}