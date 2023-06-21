global using Gurukul.Infrastructure.Data;
global using Microsoft.EntityFrameworkCore;
global using Gurukul.Infrastructure.Models;
global using Gurukul.Infrastructure.ViewModel;
using Gurukul.Infrastructure.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Gurukul.Infrastructure.Constants;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GurukulDbContext>().AddDefaultUI();
/*builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Identity/Account/Login");
});*/

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissions.Contact.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Contact.View));
    });

    options.AddPolicy(Permissions.Contact.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Contact.Create));
    });
    options.AddPolicy(Permissions.Contact.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Contact.Edit));
    });
    options.AddPolicy(Permissions.Contact.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Contact.Delete));
    });
    options.AddPolicy(Permissions.Donation.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Donation.View));
    });
    options.AddPolicy(Permissions.Donation.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Donation.Create));
    });
    options.AddPolicy(Permissions.Donation.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Donation.Edit));
    });
    options.AddPolicy(Permissions.Donation.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Donation.Delete));
    });
    options.AddPolicy(Permissions.Event.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Event.View));
    });
    options.AddPolicy(Permissions.Event.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Event.Create));
    });
    options.AddPolicy(Permissions.Event.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Event.Edit));
    });
    options.AddPolicy(Permissions.Event.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Event.Delete));
    });
    options.AddPolicy(Permissions.Magazine.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Magazine.View));
    });
    options.AddPolicy(Permissions.Magazine.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Magazine.Create));
    });
    options.AddPolicy(Permissions.Magazine.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Magazine.Edit));
    });
    options.AddPolicy(Permissions.Magazine.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Magazine.Delete));
    });
    options.AddPolicy(Permissions.Mail.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Mail.View));
    });
    options.AddPolicy(Permissions.Mail.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Mail.Create));
    });
    options.AddPolicy(Permissions.Mail.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Mail.Edit));
    });
    options.AddPolicy(Permissions.Mail.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Mail.Delete));
    });
});
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSession();

builder.Services.AddDbContext<GurukulDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CRMConnectionString")));
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
});
var app = builder.Build();
var serviceprovider = app.Services;
using var scope = serviceprovider.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("app");
try
{
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await Gurukul.Infrastructure.Seeds.DefaultRoles.SeedAsync(roleManager);
    await Gurukul.Infrastructure.Seeds.DefaultUsers.SeedBasicUserAsync(userManager);
    await Gurukul.Infrastructure.Seeds.DefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);
    logger.LogInformation("Finished Seeding Default Data");
    logger.LogInformation("Application Starting");

}
catch (Exception ex)
{
    logger.LogWarning(ex, "An error occurred seeding the DB");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=dashboard}/{action=Index}/{id?}");
app.Run();