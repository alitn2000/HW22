using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.TaskManager.UserAggrigate.Contracts;

public interface IUserService
{
    Task<IdentityResult> RegisterAsync(AppUser user, string pass, CancellationToken cancel);
    Task<SignInResult> LoginAsync(string userName, string pass);



}
