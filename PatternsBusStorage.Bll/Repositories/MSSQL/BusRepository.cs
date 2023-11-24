using Dapper;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Dal;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Exceptions.DbExceptions;

namespace PatternsBusStorage.Bll.Repositories;

public class BusRepository : IBusRepository
{
    
    private readonly SqlConnectionPool _sqlConnectionPool;

    public BusRepository(SqlConnectionPool sqlConnectionPool)
    {
        _sqlConnectionPool = sqlConnectionPool;
    }
    
    public async Task<Bus> GetById(int id)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "SELECT * FROM Bus" +
                  " WHERE BusId = @BusId";

        var res = await connection.QueryAsync<Bus>(sql, new{BusId = id});

        if (!res.Any())
        {
            throw new 
                RecordNotFoundException($"The bus with id {id} not found in the database, and could not be retreived");
        }
        _sqlConnectionPool.ReturnConnection(connection);
        return res.First();
    }
    
    public async Task<Bus> GetBusByNumber(string number)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "SELECT * FROM Bus" +
                  " WHERE BusNumber = @BusNumber";

        var res = await connection.QueryAsync<Bus>(sql, new{BusNumber = number});

        if (!res.Any())
        {
            throw new 
                RecordNotFoundException($"The bus with id {number} not found in the database, and could not be retreived");
        }
        _sqlConnectionPool.ReturnConnection(connection);
        return res.First();
    }

    public async Task<IEnumerable<Bus>> GetAll()
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "SELECT * FROM Bus";
        
        var res = await connection.QueryAsync<Bus>(sql);
        _sqlConnectionPool.ReturnConnection(connection);
        return res;
    }

    public async Task<Bus> Add(Bus entity)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var bus = 
            new { entity.BusNumber, entity.Model, entity.ManufacturingYear, entity.Capacity, entity.Status };

        var sql = "INSERT INTO Bus (BusNumber, Model, ManufacturingYear, Capacity, Status)" +
                  "VALUES (@BusNumber, @Model, @ManufacturingYear, @Capacity, @Status)";

        await connection.ExecuteAsync(sql, bus);
        _sqlConnectionPool.ReturnConnection(connection);
            
        return new Bus();
    }

    public async Task<Bus> Update(Bus entity)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var bus = new
            {entity.BusId, entity.BusNumber, entity.Model, entity.ManufacturingYear, entity.Capacity, entity.Status};

        var sql = "UPDATE Bus SET BusNumber = @BusNumber, Model = @Model," +
                  " ManufacturingYear = @ManufacturingYear, Capacity = @Capacity, Status = @Status" +
                  " WHERE BusId = @BusId";

        var res = await connection.ExecuteAsync(sql, bus);

        if (res < 1) { throw new 
                RecordNotFoundException
                ($"The bus with id {entity.BusId} not found in the database, and could not be updated"); }
        _sqlConnectionPool.ReturnConnection(connection);
        return new Bus();
    }
    
    public async Task<Bus> UpdateBusByNumber(Bus entity)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var bus = new
            {entity.Model, entity.ManufacturingYear, entity.Capacity, entity.Status, entity.BusNumber};

        var sql = "UPDATE Bus SET Model = @Model," +
                  " ManufacturingYear = @ManufacturingYear, Capacity = @Capacity, Status = @Status" +
                  " WHERE BusNumber = @BusNumber";

        var res = await connection.ExecuteAsync(sql, bus);

        if (res < 1)
        {
            throw new 
                RecordNotFoundException($"The bus with id {entity.BusId} not found in the database, and could not be updated");
        }
        _sqlConnectionPool.ReturnConnection(connection);
        return new Bus();
    }

    public async Task<string> Delete(int id)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "DELETE FROM Bus WHERE BusId = @BusId";

        var res = await connection.ExecuteAsync(sql, new {BudId = id});

        if (res < 1)
        {
            throw new 
                RecordNotFoundException($"The bus with id {id} was not found in the database, and could not be deleted");
        }
        _sqlConnectionPool.ReturnConnection(connection);
        return "Bus deleted successfully";
    }
}