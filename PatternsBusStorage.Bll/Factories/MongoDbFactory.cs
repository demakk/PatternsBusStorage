using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Bll.Repositories.MongoDB;

namespace PatternsBusStorage.Bll.Factories;

public class MongoDbFactory : IRepositoryFactory
{
    public IBusRepository CreateBusRepository()
    {
        return new MongoDbBusRepository();
    }

    public IUserActionsRepository CreateUserActionsRepository()
    {
        return new UserActionsMongoDbRepository();
    }

    public IScheduleRepository CreateScheduleRepository()
    {
        return new MongoDbScheduleRepository();
    }
}