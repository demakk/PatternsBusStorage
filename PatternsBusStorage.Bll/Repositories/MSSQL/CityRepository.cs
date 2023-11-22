using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Exceptions.DbExceptions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;

namespace PatternsBusStorage.Bll.Repositories;

public class CityRepository : IRepository<City>
{

    private readonly string _connectionString;
    
    public CityRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public async Task<City> GetById(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "SELECT * FROM City" +
                  " WHERE CityId = @CityId";

        var res = await connection.QueryAsync<City>(sql, new{CityId = id});

        if (!res.Any())
        {
            throw new 
                RecordNotFoundException($"The city with id {id} not found in the database, and could not be retreived");
        }

        return res.First();
    }

    public async Task<IEnumerable<City>> GetAll()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "SELECT * FROM City";
        
        var res = await connection.QueryAsync<City>(sql);
        await connection.CloseAsync();
        return res;
    }

    public async Task<City> Add(City entity)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        var city = new { entity.CityName, entity.EstablishedYear };

        var sql = "INSERT INTO City (CityName, EstablishedYear)" +
                  "VALUES (@CityName, @EstablishedYear)";

        await connection.ExecuteAsync(sql, city);
        await connection.CloseAsync();
            
        return new City();
    }

    public async Task<City> Update(City entity)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var city = new { entity.CityName, entity.EstablishedYear, entity.CityId };

        var sql = "UPDATE City SET CityName = @CityName, EstablishedYear = @EstablishedYear" +
                  " WHERE CityId = @CityId";

        var res = await connection.ExecuteAsync(sql, city);

        if (res < 1)
        {
            throw new 
                RecordNotFoundException($"The city with id {entity.CityId} not found in the database, and could not be updated");
        }

        return new City();
    }

    public async Task<string> Delete(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var sql = "DELETE FROM City WHERE CityId = @CityId";

        var res = await connection.ExecuteAsync(sql, new {CityId = id});

        if (res < 1)
        {
            throw new 
                RecordNotFoundException($"The city with id {id} was not found in the database, and could not be deleted");
        }

        return "City deleted successfully";
    }
}