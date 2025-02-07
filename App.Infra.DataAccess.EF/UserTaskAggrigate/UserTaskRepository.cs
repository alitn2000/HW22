using App.Domain.Core.TaskManager.TaskAggrigate.Contracts;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using App.Infra.Data.SqlService.Ef;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace App.Infra.DataAccess.EF.UserTaskAggrigate;

public class UserTaskRepository :IUserTaskRepository
{
    public readonly TaskManagerDb _context;
    public UserTaskRepository(TaskManagerDb context)
    {
        _context = context;
    }

    public async Task<bool> AddTaskAsync(int userId, UserTask userTask,CancellationToken cancel)
    {
        try
        {
            userTask.UserId = userId;
            userTask.RegisterTime = DateTime.Now;

            await _context.UserTasks.AddAsync(userTask, cancel);
            int counter = await _context.SaveChangesAsync(cancel);

            return counter > 0;
        }
        catch
        {
            return false;
        }

    }

    public async Task<List<UserTask>?> GetAllAsync(int userId ,CancellationToken cancel)
    {
        return await _context.UserTasks.Where(u => u.UserId == userId && u.IsCompleted ==false).ToListAsync(cancel);
    }

    public async Task<UserTask?> GetAsync(int userId, int userTask,CancellationToken cancel)
    {
        return await _context.UserTasks.FirstOrDefaultAsync(u =>u.UserId == userId && u.Id == userTask, cancel); 
    }

    public async Task<bool> ChangeIscompleteAsync(int userId,int taskId,bool status, CancellationToken cancel)
    {
        var task =  await _context.UserTasks.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId, cancel);
        if (task != null)
        {
            task.IsCompleted = status;
            int counter = await _context.SaveChangesAsync(cancel);
            return counter > 0;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(UserTask userTask, CancellationToken cancel)
    {
        _context.Remove(userTask);
        int counter = await _context.SaveChangesAsync(cancel);
        return counter > 0;
    }

    public async Task<bool> CheckTaskLimitAsync(int userId,int limit,CancellationToken cancel)
    {
      int tasks =  await _context.UserTasks.Where(u => u.UserId == userId && u.IsCompleted ==false).CountAsync(cancel);
        if (tasks < limit)
            return true;
        return false;

    }

    public async Task<bool> UpdateAsync(int userId, UserTask userTask, CancellationToken cancel) 
    {
        try
        {
            var existingTask = await _context.UserTasks
                .FirstOrDefaultAsync(t => t.Id == userTask.Id && t.UserId == userId, cancel);

            if (existingTask == null)
                return false; 

            existingTask.Title = userTask.Title;
            existingTask.Description = userTask.Description;
            existingTask.IsCompleted = userTask.IsCompleted;
            existingTask.DeadTime = userTask.DeadTime;

            int counter = await _context.SaveChangesAsync(cancel);
            return counter > 0;
        }
        catch
        {
            return false;
        }
    }

}
