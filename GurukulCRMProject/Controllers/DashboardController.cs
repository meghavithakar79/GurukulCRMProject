using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers;
[Authorize]
public class DashboardController : Controller
{

    private readonly GurukulDbContext _context;
    public DashboardController(GurukulDbContext context)
    {
        _context = context;
      
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Index()
    {
        int num = _context.Users.Count();
        TempData["ResultOk"] = num;
        return View();
    }
}
