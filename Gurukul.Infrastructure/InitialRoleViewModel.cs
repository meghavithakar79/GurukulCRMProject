using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gurukul.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gurukul.Infrastructure
{
    public class InitialRoleViewModel
    {
        private readonly RoleManager<AppRole> _roleManager;
        public InitialRoleViewModel(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public InitialRoleViewModel()
        {
        }
        public class InputModel
        {
            public int Id { get; set; }
            public string Role { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
        }
        public InputModel Input { get; set; }
        public void OnGet()
        {
            Input = new InputModel()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
           
        }
    }
}
