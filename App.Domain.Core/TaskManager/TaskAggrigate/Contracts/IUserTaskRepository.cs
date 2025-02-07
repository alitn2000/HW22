using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TaskManager.TaskAggrigate.Contracts;

public interface IUserTaskRepository
{
    Task<bool> AddTaskAsync(int userId, UserTask userTask, CancellationToken cancel);
    Task<List<UserTask>?> GetAllAsync(int userId, CancellationToken cancel);
    Task<bool> DeleteAsync(UserTask userTask, CancellationToken cancel);
    Task<UserTask?> GetAsync(int userId, int userTask, CancellationToken cancel);
    Task<bool> CheckTaskLimitAsync(int userId, int limit, CancellationToken cancel);
    Task<bool> UpdateAsync(int userId, UserTask userTask, CancellationToken cancel);
}
