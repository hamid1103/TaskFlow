using TaskFlowBackend.Models;

namespace TaskFlowBackend.Repositories.TaskRepository;

public interface ITaskRepository
{
    public Task<List<PersonalTask>> GetAllAsync(int page, int pageSize, int userId);
    public Task<List<PersonalTask>> GetAllAsync(int userId);
    public Task<PersonalTask?> GetByIdAsync(int id, int userId);
    public Task<int> GetTotalCountAsync(int userId);
    
    //Make sure to confirm userId in controller
    public Task CreateAsync(PersonalTask personalTask);
    
    //Make sure to confirm userId in controller
    public Task UpdateAsync(PersonalTask personalTask);

}