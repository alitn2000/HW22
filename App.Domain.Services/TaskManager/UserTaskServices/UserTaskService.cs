using App.Domain.Core.TaskManager.ResultAggrigate.Entity;
using App.Domain.Core.TaskManager.TaskAggrigate.Contracts;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using Microsoft.Extensions.Configuration;

namespace App.Domain.Services.TaskManager.UserTaskServices
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IConfiguration _configuration;
        public UserTaskService(IUserTaskRepository userTaskRepository, IConfiguration configuration)
        {
            _userTaskRepository = userTaskRepository;
            _configuration = configuration;
        }

        public async Task<Result> AddUserTaskAsync(int userId, UserTask userTask, CancellationToken cancel)
        {

            if (await _userTaskRepository.AddTaskAsync(userId, userTask, cancel))
                return new Result(true, "Task added successfully");

            return new Result(false, "Logic Error");


        }

        public async Task<Result> CheckUserTaskLimitAsync(int userId, CancellationToken cancel)
        {
            int limit = int.Parse(_configuration.GetSection("TasksLimit").Value);
            if (await _userTaskRepository.CheckTaskLimitAsync(userId, limit, cancel))
                return new Result(true, "");

            return new Result(false, "Not completed task Limit error");

        }

        public async Task<Result> DeleteUserTaskAsync(UserTask userTask, CancellationToken cancel)
        {
            if (await _userTaskRepository.DeleteAsync(userTask, cancel))
                return new Result(true, "Task deleted successfully");
            return new Result(false, "Logic error");

        }

        public async Task<List<UserTask>?> GetAllUserTasksAsync(int userId,CancellationToken cancel)
        {
            return await _userTaskRepository.GetAllAsync(userId, cancel);
        }

        public async Task<UserTask?> GetUserTaskAsync(int userId, int taskId, CancellationToken cancel)
        {
            return await _userTaskRepository.GetAsync(userId,taskId, cancel);
        }

       public async Task<Result> UpdateTaskAsync(int userId, UserTask userTask, CancellationToken cancel)
        {
            if (await _userTaskRepository.UpdateAsync(userId, userTask, cancel))
                return new Result(true, "Task updated successfully");

            return new Result(false, "Logic error");
        }
    }
}
