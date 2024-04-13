using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaReceitas.Infra.Data
{
    public static class Connection
    {
        public static IDbConnection ConnectDatabase()
            => new MySqlConnection(Environment.GetEnvironmentVariable("DATABASE_CONNECTION"));
    }
}
