using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public async Task<bool> IsUsernameTaken(string username)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT * FROM Users WHERE Username = @Username";
        var res = await connection.QueryAsync<User>(sql, new { Username = username });

        return res.Any();
    }

    public async Task<string> AddUser(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var sql = "INSERT INTO Users (Username, Password, RoleId) VALUES (@Username, @Password, @RoleId)";
        await connection.ExecuteAsync(sql, user);

        return user.ToString();
    }

    public async Task<User> AuthenticateUser(string username, string password)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
        return connection.QuerySingleOrDefault<User>(sql, new { Username = username, Password = password });
    }
}