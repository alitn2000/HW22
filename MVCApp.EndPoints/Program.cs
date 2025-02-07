using App.Domain.Core.TaskManager.TaskAggrigate.Contracts;
using App.Domain.Core.TaskManager.UserAggrigate.Contracts;
using App.Domain.Core.TaskManager.UserAggrigate.Entity;
using App.Infra.Data.SqlService.Ef;
using App.Infra.DataAccess.EF.UserTaskAggrigate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using App.Domain.Services.AppServices.UserTaskAggrigate;
using App.Domain.Services.TaskManager.UserTaskServices;
using App.Domain.AppServices.UserAggrigate;
using App.Domain.Services.TaskManager.UserServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("TurnsDb");
builder.Services.AddDbContext<TaskManagerDb>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
builder.Services.AddScoped<IUserTaskAppService, UserTaskAppService2>();
builder.Services.AddScoped<IUserTaskService, UserTaskService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(op =>
{
    op.Password.RequiredLength = 4;
    op.Password.RequireUppercase = false;
    op.Password.RequireLowercase = false;
    op.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<TaskManagerDb>();

var app = builder.Build();



//Tasks




//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
