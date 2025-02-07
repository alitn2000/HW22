using App.Domain.Core.TaskManager.UserAggrigate.Contracts;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.UserAggrigate;

public class UserAppService : IUserAppService
{

    private readonly IUserService _userService;

    public UserAppService(IUserService userService)
    {
        _userService = userService;
    }

    public async  Task<SignInResult> LoginUserAsync(string userName, string pass)
    {
        return await _userService.LoginAsync(userName, pass);
    }

    public async Task<IdentityResult> RegisterUserAsync(AppUser user, string pass, CancellationToken cancel)
    {
        return await _userService.RegisterAsync(user, pass, cancel);
    }
}
