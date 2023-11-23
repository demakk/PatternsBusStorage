using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Dal;
using PatternsBusStorage.Domain.Aggregates;
using PatternsBusStorage.Domain.Exceptions.DbExceptions;

namespace PatternsBusStorage.Bll.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly SqlConnectionPool _sqlConnectionPool;

    public ScheduleRepository(SqlConnectionPool connectionPool)
    {
        _sqlConnectionPool = connectionPool;
    }

    public async Task<Schedule> GetById(int id)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "SELECT * FROM Schedule" +
                  " WHERE ScheduleId = @ScheduleId";

        var res = await connection.QueryAsync<Schedule>(sql, new { ScheduleId = id });

        if (!res.Any())
        {
            throw new RecordNotFoundException($"The schedule with id {id} not found in the database, and could not be retreived");
        }

        return res.First();
    }

    public async Task<IEnumerable<Schedule>> GetAll()
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "SELECT * FROM Schedule";

        var res = await connection.QueryAsync<Schedule>(sql);
        await connection.CloseAsync();
        return res;
    }

    public async Task<Schedule> Add(Schedule entity)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var schedule = new { entity.BusId, entity.RouteId, entity.StopId, entity.DepartureTime, entity.ArrivalTime };

        var sql = "INSERT INTO Schedule (BusId, RouteId, StopId, DepartureTime, ArrivalTime)" +
                  "VALUES (@BusId, @RouteId, @StopId, @DepartureTime, @ArrivalTime)";

        await connection.ExecuteAsync(sql, schedule);
        await connection.CloseAsync();

        return new Schedule();
    }

    public async Task<Schedule> Update(Schedule entity)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var schedule = new { entity.ScheduleId, entity.BusId, entity.StopId, entity.DepartureTime, entity.ArrivalTime };

        var sql = "UPDATE Schedule SET BusId = @BusId, StopId = @StopId, DepartureTime = @DepartureTime, ArrivalTime = @ArrivalTime" +
                  " WHERE ScheduleId = @ScheduleId";

        var res = await connection.ExecuteAsync(sql, schedule);

        if (res < 1)
        {
            throw new RecordNotFoundException($"The schedule with id {entity.ScheduleId} not found in the database, and could not be updated");
        }

        return new Schedule();
    }

    public async Task<string> Delete(int id)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var sql = "DELETE FROM Schedule WHERE ScheduleId = @ScheduleId";

        var res = await connection.ExecuteAsync(sql, new { ScheduleId = id });

        if (res < 1)
        {
            throw new RecordNotFoundException($"The schedule with id {id} was not found in the database, and could not be deleted");
        }

        return "Schedule deleted successfully";
    }
}