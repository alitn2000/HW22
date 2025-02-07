using App.Domain.Core.TaskManager.UserAggrigate.Contracts;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading;
namespace App.Domain.Services.TaskManager.UserServices;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<IdentityResult> RegisterAsync(AppUser user, string pass, CancellationToken cancel)
    {
        return await Task.Run(() => _userManager.CreateAsync(user, pass), cancel);

       
    }

   
    public async Task<SignInResult> LoginAsync(string userName, string pass)
    {
        return await _signInManager.PasswordSignInAsync(userName, pass, true, false);
    }


}
