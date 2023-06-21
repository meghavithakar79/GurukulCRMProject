using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly GurukulDbContext _context;
        public SubscribeController(GurukulDbContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Permissions.Magazine.View)]
        public IActionResult Index()
        {
            Subscribe subscribe = new Subscribe();
            subscribe.Magazines = GetMagazines();
            return View(subscribe);
        }
        private List<Magazine> GetMagazines()
        {
            var magazine = _context.Magazines.Where(x => !x.IsDelete).ToList();
            return magazine;
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public JsonResult Index(Subscribe model)
        {
            var subscribe = new Subscribe 
            {
                Amount= model.Amount,
                EndDate=model.EndDate,
                IsPaymentConfirmed=model.IsPaymentConfirmed,
                MagazineId=model.MagazineId,
                MagazineTitle=model.MagazineTitle,
                Plan=model.Plan,
                StartDate=model.StartDate,
            };
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            
            return Json(new { Url = "/Subscribe/PaymentConfirm" });

        }
        public IActionResult PaymentConfirm()
        {
            return View();
        }
    }
}
