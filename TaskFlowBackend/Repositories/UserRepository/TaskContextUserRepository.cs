using TaskFlowBackend.Data;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories.UserRepository;

public class TaskContextUserRepository : IUserRepository
{
    private readonly TaskContext _context;

    public TaskContextUserRepository(TaskContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int id)
    {
        User? user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    
}