using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.DTOs;

namespace PatternsBusStorage.Bll.Repositories.MongoDB;

public class UserActionsMongoDbRepository : IUserActionsRepository
{
    public Task<List<ClosestBus>> GetClosestSchedule(int busId)
    {
        throw new NotImplementedException();
    }
}