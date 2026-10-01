namespace TaskFlowBackend.Models;

public class CreateTaskRequest
{
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public RecurringType Recurring { get; set; } = RecurringType.None;
}
