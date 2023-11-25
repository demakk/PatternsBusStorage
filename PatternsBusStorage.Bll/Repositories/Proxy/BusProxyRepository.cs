using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.DTOs;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Repositories.Proxy;

public class BusProxyRepository
{
    private readonly IBusRepository _realBusRepository;

    public BusProxyRepository(IBusRepository realBusRepository)
    {
        _realBusRepository = realBusRepository;
    }

    public async Task<Bus> GetById(int id)
    {
        return await _realBusRepository.GetById(id);
    }

    public async Task<Bus> GetBusByNumber(string number)
    {
        return await _realBusRepository.GetBusByNumber(number);
    }

    public async Task<IEnumerable<Bus>> GetAll()
    {
        return await _realBusRepository.GetAll();
    }

    public async Task<Bus> Add(Bus entity, string userRole)
    {
        CheckUserRole(userRole);
        return await _realBusRepository.Add(entity);
    }

    public async Task<Bus> Update(Bus entity, string userRole, int id)
    {
        CheckUserRole(userRole);
        return await _realBusRepository.Update(entity, id);
    }

    public async Task<Bus> UpdateBusByNumber(Bus entity, string userRole)
    {
        CheckUserRole(userRole);
        return await _realBusRepository.UpdateBusByNumber(entity);
    }

    public async Task<string> Delete(int id, string userRole)
    {
        CheckUserRole(userRole);
        return await _realBusRepository.Delete(id);
    }

    private void CheckUserRole(string userRole)
    {
        if (userRole != "Admin")
        {
            // Access denied for non-admin users
            throw new UnauthorizedAccessException("Access denied. User does not have the required role.");
        }
    }
}