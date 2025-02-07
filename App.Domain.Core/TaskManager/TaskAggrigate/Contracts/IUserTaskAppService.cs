using App.Domain.Core.TaskManager.ResultAggrigate.Entity;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;

namespace App.Domain.Core.TaskManager.TaskAggrigate.Contracts;

public interface IUserTaskAppService
{
    Task<Result> AddUserTaskAsync(int userId,UserTask userTask, CancellationToken cancel);
    Task<List<UserTask>?> GetAllUserTasksAsync(int userId, CancellationToken cancel);
    Task<Result> DeleteUserTaskAsync(UserTask userTask, CancellationToken cancel);
    Task<UserTask?> GetUserTaskAsync(int userid, int taskId, CancellationToken cancel);
    Task<Result> CheckUserTaskLimitAsync(int userId, CancellationToken cancel);
    Task<Result> UpdateUserTaskAsync(int userId, UserTask userTask, CancellationToken cancel);
}
