using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace App.Infra.Data.SqlService.Ef;

public class TaskManagerDb : IdentityDbContext<AppUser, IdentityRole<int>,int>
{
    public TaskManagerDb(DbContextOptions<TaskManagerDb> options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
}
