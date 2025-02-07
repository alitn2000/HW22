using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.TaskManager.TaskAggrigate.Entity;

public class UserTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime RegisterTime { get; set; }
    public DateTime DeadTime { get; set; }
    public AppUser User { get; set; }
    public int UserId { get; set; }
}
