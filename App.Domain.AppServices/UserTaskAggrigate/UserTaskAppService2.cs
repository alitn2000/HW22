using App.Domain.Core.TaskManager.ResultAggrigate.Entity;
using App.Domain.Core.TaskManager.TaskAggrigate.Contracts;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;

namespace App.Domain.Services.AppServices.UserTaskAggrigate;

public class UserTaskAppService2 : IUserTaskAppService
{
    private readonly IUserTaskService _userTaskService;

    public UserTaskAppService2(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService;
    }

    public async Task<Result> AddUserTaskAsync(int userId, UserTask userTask, CancellationToken cancel)
    {
        return await _userTaskService.AddUserTaskAsync(userId,userTask, cancel);
    }

    public async Task<Result> CheckUserTaskLimitAsync(int userId, CancellationToken cancel)
    {
        return await _userTaskService.CheckUserTaskLimitAsync(userId, cancel);
    }

    public async Task<Result> DeleteUserTaskAsync(UserTask userTask, CancellationToken cancel)
    {
        return await _userTaskService.DeleteUserTaskAsync(userTask, cancel);
    }

    public async Task<List<UserTask>?> GetAllUserTasksAsync(int userId, CancellationToken cancel)
    {
        return await _userTaskService.GetAllUserTasksAsync(userId, cancel);
    }

    public async Task<UserTask?> GetUserTaskAsync(int userid, int taskId, CancellationToken cancel)
    {
        return await _userTaskService.GetUserTaskAsync(userid, taskId, cancel);
    }

    public async Task<Result> UpdateUserTaskAsync(int userId, UserTask userTask, CancellationToken cancel)
    {
        return await _userTaskService.UpdateTaskAsync(userId, userTask, cancel);
    }
}
