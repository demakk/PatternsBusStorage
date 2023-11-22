using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Application.Repositories;

public interface IBusRepository : IRepository<Bus>
{
    public Task<Bus> UpdateBusByNumber(Bus bus);
    public Task<Bus> GetBusByNumber(string number);
}