using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Application.Repositories;

public interface IUserRepository
{
    public Task<bool> IsUsernameTaken(string username);

    public Task<string> AddUser(User user);

    public Task<User> AuthenticateUser(string username, string password);

}