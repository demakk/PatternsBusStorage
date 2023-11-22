using PatternsBusStorage.Bll.DTOs;

namespace PatternsBusStorage.Application.Repositories;

public interface IUserActionsRepository
{
    public Task<List<ClosestBus>> GetClosestSchedule(int busId);
}