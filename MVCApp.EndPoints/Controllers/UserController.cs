using App.Domain.Core.TaskManager.UserAggrigate.Contracts;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCApp.EndPoints.Models;

namespace MVCApp.EndPoints.Controllers;

public class UserController : Controller
{
    private readonly IUserAppService _userAppService;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public UserController(IUserAppService userAppService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userAppService = userAppService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModelView loginModelView, CancellationToken cancel)
    {
        if (!ModelState.IsValid)
            return View(loginModelView);

        var user = await _userManager.FindByNameAsync(loginModelView.UserName);
        if (user == null)
        {
            TempData["LoginResult"] = "User name or pass is incorrect";
            return View(loginModelView);
        }
        var result = await _userAppService.LoginUserAsync(loginModelView.UserName, loginModelView.Password);

        if (result.Succeeded)
            return RedirectToAction("TaskList", "UserTask");

        TempData["LoginResult"] = "User name or pass is incorrect";
        return View(loginModelView);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "User");
    }

    [HttpGet]
    public IActionResult Register( )
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModelView registerModelView, CancellationToken cancel)
    {
       if(!ModelState.IsValid)
            return View(registerModelView);

        AppUser user = new AppUser()
        {
            FirstName = registerModelView.FirstName,
            LastName = registerModelView.LastName,
            Email = registerModelView.Email,
            UserName = registerModelView.UserName,

        };
        var result = await _userAppService.RegisterUserAsync(user, registerModelView.Password, cancel);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "User");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(registerModelView);
    }

}
