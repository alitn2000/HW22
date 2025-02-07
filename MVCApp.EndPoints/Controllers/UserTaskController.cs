using App.Domain.Core.TaskManager.ResultAggrigate.Entity;
using App.Domain.Core.TaskManager.TaskAggrigate.Contracts;
using App.Domain.Core.TaskManager.TaskAggrigate.Entity;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using App.Domain.Services.TaskManager.UserTaskServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MVCApp.EndPoints.Models;

namespace MVCApp.EndPoints.Controllers;

[Authorize]
public class UserTaskController : Controller
{
    private readonly IUserTaskAppService _userTaskAppService;
    private readonly UserManager<AppUser> _userManager;
    public UserTaskController(IUserTaskAppService userTaskAppService, UserManager<AppUser> userManager)
    {
        _userTaskAppService = userTaskAppService;
        _userManager = userManager;
    }

    public async Task<IActionResult> TaskList(CancellationToken cancel)
    {
        var user = await _userManager.GetUserAsync(User);
        var tasks = await _userTaskAppService.GetAllUserTasksAsync(user.Id, cancel);
        return View(tasks);
    }
    
    public async Task<IActionResult> Delete(int id, CancellationToken cancel)
    {
        var user = await _userManager.GetUserAsync(User);
         var task = await _userTaskAppService.GetUserTaskAsync(user.Id, id, cancel);
        if (task == null)
        {
            TempData["TaskNotFound"] = "Task not found";
            return RedirectToAction("TaskList");
        }

        Result result = await _userTaskAppService.DeleteUserTaskAsync(task, cancel);
        if (result.Flag)
        {
            TempData["DeleteResult"] = "Task deleted successfully";
           return RedirectToAction("TaskList");
        }
        

        TempData["DeleteResult"] = "Logic Error";
        return RedirectToAction("TaskList");
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTaskModelView addTaskModelView, CancellationToken cancel)
    {
        if (!ModelState.IsValid)
            return View(addTaskModelView);
        var user = await _userManager.GetUserAsync(User);
        var result = await _userTaskAppService.CheckUserTaskLimitAsync(user.Id, cancel);

        if (!result.Flag)
        {
            TempData["TaskLimit"] = result.Message;
            return View(addTaskModelView);
        }

        var userTask = new UserTask()
        {
            Title = addTaskModelView.Title,
            DeadTime = addTaskModelView.DeadTime,
            Description = addTaskModelView.Description,
        };

        var result2 = await _userTaskAppService.AddUserTaskAsync(user.Id,userTask, cancel);

        if (result2.Flag)
        {
            TempData["AddResult"] = result2.Message;
            return View(addTaskModelView);
        }

            TempData["AddResult"] = result2.Message;
            return View();
        
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id, CancellationToken cancel)
    {
        var user = await _userManager.GetUserAsync(User);
        var task = await _userTaskAppService.GetUserTaskAsync(user.Id, id, cancel);
        if (task == null)
        {
            TempData["UpdateMessage"] = "Task not found";
            return RedirectToAction("Update");
        }
        var taskModel = new UpdateTaskModelView
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DeadTime = task.DeadTime,
            IsCompelete = task.IsCompleted
        };

        return View(taskModel);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateTaskModelView updateTaskModelView, CancellationToken cancel)
    {
        if(!ModelState.IsValid)
            return View(updateTaskModelView);
        var user = await _userManager.GetUserAsync(User);

        var taskExist = await _userTaskAppService.GetUserTaskAsync(user.Id, updateTaskModelView.Id, cancel);
        if (taskExist == null)
        {
            TempData["FoundTask"] = "Task not found";
            return View(updateTaskModelView);
        }

        taskExist.Title = updateTaskModelView.Title;
        taskExist.Description = updateTaskModelView.Description;
        taskExist.DeadTime = updateTaskModelView.DeadTime;
        taskExist.IsCompleted = updateTaskModelView.IsCompelete;

        var result = await _userTaskAppService.UpdateUserTaskAsync(user.Id,taskExist, cancel);

        if (result.Flag)
            return RedirectToAction("TaskList");

        TempData["UpdateResult"] = result.Message;
        return RedirectToAction("TaskList");
    }
}
