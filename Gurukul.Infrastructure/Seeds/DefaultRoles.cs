using Gurukul.Infrastructure.Constants;
using Gurukul.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<AppRole>
            {
                new AppRole{Name = "SuperAdmin"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Basic"},
            };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
