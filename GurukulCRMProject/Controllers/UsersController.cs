using Gurukul.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GurukulCRMProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager; 
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {

            var userList = await _userManager.Users.ToListAsync();
            var usersWithRoles = new List<UserViewModel>();

            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles
                };
                usersWithRoles.Add(userViewModel);
            }

            return View(usersWithRoles);
        }
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user= await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var roles=await _roleManager.Roles.ToListAsync();
            var viewModel = new UserRolesViewModel 
            {
                UserId=user.Id,
                UserName=user.UserName,
                Roles=roles.Select(role=> new RoleViewModel 
                {
                    RoleName=role.Name,
                    IsSelected=_userManager.IsInRoleAsync(user,role.Name).Result
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var userroles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user,userroles);
            await _userManager.AddToRolesAsync(user,model.Roles.Where(r=>r.IsSelected).Select(r=>r.RoleName));
            return RedirectToAction(nameof(Index));
        }
    }
}
