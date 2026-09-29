namespace TaskFlowBackend.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string ProfilePicture { get; set; }
    
    public ICollection<PersonalTask> Tasks { get; set; } = new List<PersonalTask>();
}