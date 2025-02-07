using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
namespace App.Domain.Core.TaskManager.UserAggrigate.Entity;

public class AppUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<UserTask> UserTasks { get; set; }
}
