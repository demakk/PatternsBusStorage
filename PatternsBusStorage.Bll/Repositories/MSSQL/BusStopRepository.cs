using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Exceptions.DbExceptions;

namespace PatternsBusStorage.Bll.Repositories;

public class BusStopRepository : IRepository<BusStop>
{
private readonly string _connectionString;

    public BusStopRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public async Task<BusStop> GetById(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = "SELECT * FROM BusStop" +
                           " WHERE StopId = @StopId";

        var res = await connection.QueryAsync<BusStop>(sql, new { StopId = id });

        if (!res.Any())
        {
            throw new RecordNotFoundException($"The bus stop with id {id} not found in the database, and could not be retreived");
        }

        return res.First();
    }

    public async Task<IEnumerable<BusStop>> GetAll()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = "SELECT * FROM BusStop";

        var res = await connection.QueryAsync<BusStop>(sql);
        await connection.CloseAsync();
        return res;
    }

    public async Task<BusStop> Add(BusStop entity)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var busStop = new { entity.StopName, entity.Latitude, entity.Longitude, entity.LocationDescription, entity.CityId };

        const string sql = "INSERT INTO BusStop (StopName, Latitude, Longitude, LocationDescription, CityId)" +
                           "VALUES (@StopName, @Latitude, @Longitude, @LocationDescription, @CityId)";

        await connection.ExecuteAsync(sql, busStop);
        await connection.CloseAsync();

        return new BusStop();
    }

    public async Task<BusStop> Update(BusStop entity, int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var busStop = new { entity.StopName, entity.Latitude, entity.Longitude, entity.LocationDescription, entity.CityId, entity.StopId };

        const string sql = "UPDATE BusStop SET StopName = @StopName, Latitude = @Latitude, Longitude = @Longitude, LocationDescription = @LocationDescription, CityId = @CityId" +
                           " WHERE StopId = @StopId";

        var res = await connection.ExecuteAsync(sql, busStop);

        if (res < 1)
        {
            throw new RecordNotFoundException($"The bus stop with id {entity.StopId} not found in the database, and could not be updated");
        }

        return new BusStop();
    }

    public async Task<string> Delete(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = "DELETE FROM BusStop WHERE StopId = @StopId";

        var res = await connection.ExecuteAsync(sql, new { StopId = id });

        if (res < 1)
        {
            throw new RecordNotFoundException($"The bus stop with id {id} was not found in the database, and could not be deleted");
        }

        return "Bus stop deleted successfully";
    }
}