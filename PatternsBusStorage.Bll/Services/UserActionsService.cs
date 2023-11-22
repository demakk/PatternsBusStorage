using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.DTOs;

namespace PatternsBusStorage.Bll.Services;

public class UserActionsService
{
    private readonly IUserActionsRepository _userActionsRepository;

    public UserActionsService(IUserActionsRepository userActionsRepository)
    {
        _userActionsRepository = userActionsRepository;
    }

    public async Task<List<ClosestBus>> GetClosestBuses(int busId)
    {
        return await _userActionsRepository.GetClosestSchedule(busId);
    }
    
    public async Task<List<ClosestBus>> GetAllBuses(int busId)
    {
        return await _userActionsRepository.GetClosestSchedule(busId);
    }
}