using Microsoft.Data.SqlClient;
using System.Data;

namespace Crm.Api.Services.Implementation
{
    public class DbConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
