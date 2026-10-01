using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories.UserRepository;

public interface IUserRepository
{
    public Task<User> GetUserById(int id);
    public Task CreateUser(User user);
    public Task UpdateUser(User user);
    public Task<User> GetUserIdByName(string name);
}