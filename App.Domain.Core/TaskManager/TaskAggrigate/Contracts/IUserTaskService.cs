using App.Domain.Core.TaskManager.ResultAggrigate.Entity;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TaskManager.TaskAggrigate.Contracts;

public interface IUserTaskService
{
    Task<Result> AddUserTaskAsync(int userId, UserTask userTask, CancellationToken cancel);
    Task<List<UserTask>?> GetAllUserTasksAsync(int userId, CancellationToken cancel);
    Task<Result> DeleteUserTaskAsync(UserTask userTask, CancellationToken cancel);
    Task<UserTask?> GetUserTaskAsync(int userId, int taskId, CancellationToken cancel);
    Task<Result> CheckUserTaskLimitAsync(int userId, CancellationToken cancel);
    Task<Result> UpdateTaskAsync(int userId, UserTask userTask, CancellationToken cancel);
}
