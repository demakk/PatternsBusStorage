using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Repositories.MongoDB;

public class MongoDbBusRepository : IBusRepository
{
    public Task<Bus> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bus>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Bus> Add(Bus entity)
    {
        throw new NotImplementedException();
    }

    public Task<Bus> Update(Bus entity)
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Bus> UpdateBusByNumber(Bus bus)
    {
        throw new NotImplementedException();
    }

    public Task<Bus> GetBusByNumber(string number)
    {
        throw new NotImplementedException();
    }
}