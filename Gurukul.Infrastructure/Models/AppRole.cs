using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {
            // Additional initialization logic if needed
        }

        public AppRole(string roleName) : base(roleName)
        {
            // Additional initialization logic if needed
        }

    }
}
