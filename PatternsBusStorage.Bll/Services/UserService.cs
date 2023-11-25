using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public async Task<User> AuthenticateUser(string username, string password)
    {
        return await _userRepository.AuthenticateUser(username, password);
    }
}