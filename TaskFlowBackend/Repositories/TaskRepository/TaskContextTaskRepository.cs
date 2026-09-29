using Microsoft.EntityFrameworkCore;
using TaskFlowBackend.Data;
using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories.TaskRepository;

public class TaskContextTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;
    public TaskContextTaskRepository(TaskContext context)
    {
        this._context = context;
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Tasks.CountAsync();
    }
    
    public async Task<List<PersonalTask>> GetAllAsync()
    {
        return await GetAllAsync(1, 25);
    }
    
    public async Task<List<PersonalTask>> GetAllAsync(int page, int pageSize)
    {
        List<PersonalTask> tasks = await _context.Tasks.Take(pageSize).Skip((page-1)*pageSize).ToListAsync();
        return tasks;
    }

    public async Task<PersonalTask> GetByIdAsync(int id)
    {
        PersonalTask? task = await _context.Tasks.FindAsync(id);
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