using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Repositories.MongoDB;

public class MongoDbScheduleRepository : IScheduleRepository
{
    public Task<Schedule> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Schedule>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Schedule> Add(Schedule entity)
    {
        throw new NotImplementedException();
    }

    public Task<Schedule> Update(Schedule entity, int id)
    {
        throw new NotImplementedException();
    }

    public Task<Schedule> Update(Schedule entity)
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }
}