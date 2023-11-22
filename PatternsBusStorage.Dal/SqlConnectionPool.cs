using System.Collections.Concurrent;
using Microsoft.Data.SqlClient;

namespace PatternsBusStorage.Dal;

public class SqlConnectionPool
{
    private readonly ConcurrentBag<SqlConnection> _connections;
    private readonly string _connectionString;

    public SqlConnectionPool(string connectionString)
    {
        _connectionString = connectionString;
        _connections = new ConcurrentBag<SqlConnection>();
    }

    public async Task<SqlConnection> GetConnectionAsync()
    {
        if (_connections.TryTake(out var connection))
        {
            return connection;
        }

        connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        return connection;
    }

    public void ReturnConnection(SqlConnection connection)
    {
        _connections.Add(connection);
    }
}