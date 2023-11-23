using Microsoft.Extensions.Configuration;
using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Bll.Repositories.MongoDB;
using PatternsBusStorage.Dal;

namespace PatternsBusStorage.Bll;

public static class DbRepositories
{
    public static IBusRepository GetBusRepository(DbTypes type, IConfiguration configuration)
    {
        return type switch
        {
            DbTypes.Mssql => new BusRepository(new SqlConnectionPool(configuration.GetConnectionString("DapperString"))),
            DbTypes.MongoDb => new MongoDbBusRepository(),
            _ => throw new NotImplementedException()
        };
    }
}