using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
        /*[HttpPost]
        public ActionResult Index(Subscribe model)
        {
            var subscribe = new Subscribe
            {
                Amount = model.Amount,
                EndDate = model.EndDate,
                IsPaymentConfirmed = model.IsPaymentConfirmed,
                MagazineId = model.MagazineId,
                MagazineTitle = model.MagazineTitle,
                Plan = model.Plan,
                StartDate = model.StartDate,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return View(nameof(PaymentConfirm));
            //return Json(new { Url = "/Subscribe/PaymentConfirm" });

        }*/
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string firstName = form["FirstName"];
            string lastName = form["LastName"];
            string email = form["Email"];
            string phoneNumber = form["PhoneNumber"];
            string plan = form["Plan"];
            string isPaymentConfirmed = form["IsPaymentConfirmed"];
            string amount = form["Amount"];
            string endDate = form["EndDate"];
            string startDate = form["StartDate"];

            string selectedEventsJson = form["selectedEventsInput"];

            List<Subscribe> selectedEvents = JsonSerializer.Deserialize<List<Subscribe>>(selectedEventsJson);

            foreach (var selectedEvent in selectedEvents)
            {
                string magazineId = selectedEvent.MagazineId;
                string magazineTitle = selectedEvent.MagazineTitle;

                var sub = new Subscribe
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Plan = plan,
                    IsPaymentConfirmed = Convert.ToBoolean(isPaymentConfirmed),
                    Amount=amount,
                    EndDate=Convert.ToDateTime(endDate),
                    StartDate= Convert.ToDateTime(startDate),
                    MagazineId=magazineId,
                    MagazineTitle=magazineTitle
                };
                _context.Subscribes.Add(sub);
                _context.SaveChanges();
            }
            return View(nameof(PaymentConfirm));
        }
        public IActionResult PaymentConfirm()
        {
            return View();
        }
    }
}
