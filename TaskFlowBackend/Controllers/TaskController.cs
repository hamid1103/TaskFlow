using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlowBackend.Extensions;
using TaskFlowBackend.Models;
using TaskFlowBackend.Repositories.TaskRepository;
using TaskFlowBackend.Repositories.UserRepository;

namespace TaskFlowBackend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
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
    public async Task<ActionResult<PersonalTask>> AddTask([FromBody] CreateTaskRequest request)
    {
        DateTime now = DateTime.UtcNow;
        PersonalTask task = new PersonalTask
        {
            Description = request.Description,
            Deadline = request.Deadline,
            Recurring = request.Recurring,
            Created = now,
            LastUpdated = now,
            //Always take the owner from the token, never from the request body
            UserId = User.GetUserId()
        };

        await _taskRepository.CreateAsync(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpGet]
    public async Task<List<PersonalTask>> GetTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
    {
        return await _taskRepository.GetAllAsync(page, pageSize, User.GetUserId());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PersonalTask>> GetTask(int id)
    {
        PersonalTask? task = await _taskRepository.GetByIdAsync(id, User.GetUserId());
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }

    [HttpGet("count")]
    public async Task<int> GetTotalCount()
    {
        return await _taskRepository.GetTotalCountAsync(User.GetUserId());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PersonalTask>> UpdateTask(int id, [FromBody] UpdateTaskRequest request)
    {
        //Only finds tasks owned by the current user, so nobody can update someone else's task
        PersonalTask? task = await _taskRepository.GetByIdAsync(id, User.GetUserId());
        if (task == null)
        {
            return NotFound();
        }

        task.Description = request.Description;
        task.Deadline = request.Deadline;
        task.Recurring = request.Recurring;
        task.Completed = request.Completed;
        task.LastUpdated = DateTime.UtcNow;

        await _taskRepository.UpdateAsync(task);
        return task;
    }
    
}
