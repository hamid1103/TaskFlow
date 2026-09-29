using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories.TaskRepository;

public interface ITaskRepository
{
    public Task<List<PersonalTask>> GetAllAsync(int page, int pageSize);
    public Task<List<PersonalTask>> GetAllAsync();
    public Task<PersonalTask> GetByIdAsync(int id);
    public Task<int> GetTotalCountAsync();
    public Task CreateAsync(PersonalTask personalTask);
    public Task UpdateAsync(PersonalTask personalTask);

}