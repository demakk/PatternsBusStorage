using System.Data;
using Dapper;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.DTOs;
using PatternsBusStorage.Dal;

namespace PatternsBusStorage.Bll.Repositories;

public class UserActionsRepository : IUserActionsRepository
{

    private readonly SqlConnectionPool _sqlConnectionPool;

    public UserActionsRepository(SqlConnectionPool sqlConnectionPool)
    {
        _sqlConnectionPool = sqlConnectionPool;
    }

    public async Task<List<ClosestBus>> GetClosestSchedule(int busId)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var obj = new { StopId = busId };
        
        var res =  await connection.QueryAsync<ClosestBus>(
            "[dbo].[FindBusesAtStopInNextHour]",
            obj,
            commandType: CommandType.StoredProcedure
        );

        return res.ToList();
    }
    
    
    public async Task<List<ClosestBus>> GetAllSchedulesByBusId(int busId)
    {
        await using var connection = await _sqlConnectionPool.GetConnectionAsync();

        var obj = new { StopId = busId };
        var res =  await connection.QueryAsync<ClosestBus>(
            "[dbo].[FindBusesAtStopInNextHour]",
            obj,
            commandType: CommandType.StoredProcedure
        );

        return res.ToList();
    }
    
}