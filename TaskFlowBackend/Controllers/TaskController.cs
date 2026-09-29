using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Models;
using TaskFlowBackend.Repositories.TaskRepository;
using TaskFlowBackend.Repositories.UserRepository;

namespace TaskFlowBackend.Controllers;

public class TaskController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITaskRepository _taskRepository;
    public TaskController(IUserRepository userRepository, ITaskRepository taskRepository)
    {
        _userRepository = userRepository;
        _taskRepository = taskRepository;
    }

    [HttpPost(Name = "InsertTask")]
    public async Task<ActionResult> AddTask(PersonalTask task)
    {
        //No auth, yet;
        await _taskRepository.CreateAsync(task);
        return Ok();
    }

    [HttpGet]
    public async Task<List<PersonalTask>> GetTasks()
    {
        //No auth yet
        return await _taskRepository.GetAllAsync();
    }
    
}