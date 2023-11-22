using Dapper;
using PatternsBusStorage.Domain.Aggregates;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Exceptions.DbExceptions;

namespace PatternsBusStorage.Bll.Repositories;

public class BusRouteRepository : IRepository<BusRoute>
{
    
    private readonly string _connectionString;

    public BusRouteRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public async Task<BusRoute> GetById(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "SELECT * FROM Route" +
                  " WHERE RouteId = @RouteId";

        var res = await connection.QueryAsync<BusRoute>(sql, new { RouteId = id });

        if (!res.Any())
        {
            throw new RecordNotFoundException($"The bus route with id {id} not found in the database, and could not be retreived");
        }

        return res.First();
    }

    public async Task<IEnumerable<BusRoute>> GetAll()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "SELECT * FROM Route";

        var res = await connection.QueryAsync<BusRoute>(sql);
        await connection.CloseAsync();
        return res;
    }

    public async Task<BusRoute> Add(BusRoute entity)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var busRoute = new { entity.RouteName, entity.RouteDescription, entity.StartLocation, entity.EndLocation, entity.Distance };

        var sql = "INSERT INTO Route (RouteName, RouteDescription, StartLocation, EndLocation, Distance)" +
                  "VALUES (@RouteName, @RouteDescription, @StartLocation, @EndLocation, @Distance)";

        await connection.ExecuteAsync(sql, busRoute);
        await connection.CloseAsync();

        return new BusRoute();
    }

    public async Task<BusRoute> Update(BusRoute entity)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var busRoute = new { entity.RouteName, entity.RouteDescription, entity.RouteId };

        var sql = "UPDATE Route SET RouteName = @RouteName, RouteDescription = @RouteDescription" +
                  " WHERE RouteId = @RouteId";

        var res = await connection.ExecuteAsync(sql, busRoute);

        if (res < 1)
        {
            throw new RecordNotFoundException($"The bus route with id {entity.RouteId} not found in the database, and could not be updated");
        }

        return new BusRoute();
    }

    public async Task<string> Delete(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "DELETE FROM Route WHERE RouteId = @RouteId";

        var res = await connection.ExecuteAsync(sql, new { RouteId = id });

        if (res < 1)
        {
            throw new RecordNotFoundException($"The bus route with id {id} was not found in the database, and could not be deleted");
        }

        return "Bus route deleted successfully";
    }
}