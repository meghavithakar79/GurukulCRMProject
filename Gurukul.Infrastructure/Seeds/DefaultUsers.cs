using Gurukul.Infrastructure.Constants;
using Gurukul.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<AppUser> userManager)
        {
            var defualtUser = new AppUser
            {
                UserName = "basic@gmail.com",
                Email = "basic@gmail.com",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defualtUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defualtUser, "Giriraj@1234");
                await userManager.AddToRoleAsync(defualtUser, "Basic");
            }
        }
        public static async Task SeedSuperAdminUserAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var defualtUser = new AppUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defualtUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defualtUser, "Giriraj@1234");
               
                await userManager.AddToRoleAsync(defualtUser,"Basic");
                await userManager.AddToRoleAsync(defualtUser, "Admin");
                await userManager.AddToRoleAsync(defualtUser, "SuperAdmin");
            }
            await roleManager.SeedClaimsForSuperUser();
        }
        public static async Task SeedClaimsForSuperUser(this RoleManager<AppRole> roleManager)
        {
            var adminRole= await roleManager.FindByNameAsync("Admin");
            await roleManager.AddPermissionClaim(adminRole,"Contact");
        }
        public static async Task AddPermissionClaim(this RoleManager<AppRole> roleManager, AppRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsList(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}
