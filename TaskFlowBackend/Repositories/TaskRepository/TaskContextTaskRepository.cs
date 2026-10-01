using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;
using TaskFlowBackend.Repositories.UserRepository;
using TaskFlowBackend.Services;

namespace TaskFlowBackend.Repositories.TaskRepository;

public class TaskContextTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;
    public TaskContextTaskRepository(TaskContext context)
    {
        this._context = context;
    }

    public async Task<int> GetTotalCountAsync(int userId)
    {
        return await _context.Tasks.CountAsync(t => t.UserId == userId);
    }
    
    public async Task<List<PersonalTask>> GetAllAsync(int userId)
    {
        return await GetAllAsync(1, 25, userId);
    }
    
    public async Task<List<PersonalTask>> GetAllAsync(int page, int pageSize, int userId)
    {
        List<PersonalTask> tasks = await _context.Tasks
            .Where(t => t.UserId == userId)
            .OrderBy(t => t.Id)
            .Skip((page-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        return tasks;
    }

    public async Task<PersonalTask?> GetByIdAsync(int id, int userId)
    {
        //Filtering on userId means other users' tasks behave as if they don't exist
        PersonalTask? task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        return task;
    }

    public async Task CreateAsync(PersonalTask personalTask)
    {
        await _context.Tasks.AddAsync(personalTask);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PersonalTask personalTask)
    {
        _context.Tasks.Update(personalTask);
        await _context.SaveChangesAsync();
    }
    
}