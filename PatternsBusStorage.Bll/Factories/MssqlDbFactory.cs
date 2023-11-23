using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Dal;

namespace PatternsBusStorage.Bll.Factories;

public class MssqlDbFactory : IRepositoryFactory
{
    private readonly string _connectionString;


    public MssqlDbFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DapperString");
    }

    public IBusRepository CreateBusRepository()
    {
        return new BusRepository(new SqlConnectionPool(_connectionString));
    }

    public IUserActionsRepository CreateUserActionsRepository()
    {
        return new UserActionsRepository(new SqlConnectionPool(_connectionString));
    }

    public IScheduleRepository CreateScheduleRepository()
    {
        return new ScheduleRepository(new SqlConnectionPool(_connectionString));
    }
}