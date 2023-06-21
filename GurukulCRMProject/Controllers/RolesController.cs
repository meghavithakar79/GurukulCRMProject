using Gurukul.Infrastructure.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GurukulCRMProject.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles= await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View("Index", await _roleManager.Roles.ToListAsync());
            }
            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name","Role Exists!!");
                return View("Index",await _roleManager.Roles.ToListAsync());
            }
            await _roleManager.CreateAsync(new AppRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            var roleclaims=_roleManager.GetClaimsAsync(role).Result.Select(c=>c.Value).ToList();
            var allclaims = Permissions.GenerateAllPermissions();
            var allpermissions=allclaims.Select(p=> new RoleViewModel { RoleName= p}).ToList();
            foreach (var permission in allpermissions)
            {
                if (roleclaims.Any(c => c == permission.RoleName))
                {
                    permission.IsSelected = true;
                }
            }
            var viewmodel = new PermissionsFormViewModel
            {
                RoleId=roleId,
                RoleName=role.Name,
                RoleClaims=allpermissions
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(PermissionsFormViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                return NotFound();
            }
            var roleclaims = await _roleManager.GetClaimsAsync(role);
           
            foreach (var claim in roleclaims)
            {
               await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims=model.RoleClaims.Where(c=>c.IsSelected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddClaimAsync(role,new System.Security.Claims.Claim("Permission",claim.RoleName));
            }
           
            return RedirectToAction(nameof(Index));
        }
    }
}
