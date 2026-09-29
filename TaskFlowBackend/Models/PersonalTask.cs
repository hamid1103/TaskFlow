namespace TaskFlowBackend.Models;

public class PersonalTask
{
    public int Id { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Description { get; set; }
    public RecurringType Recurring { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}