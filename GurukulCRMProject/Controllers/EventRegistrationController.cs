using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class EventRegistrationController : Controller
    {
        private readonly GurukulDbContext _context;
        public EventRegistrationController(GurukulDbContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Permissions.Event.View)]
        public IActionResult Index()
        {
            EventRegistration eventreg = new EventRegistration();
            eventreg.events = GetEvents();
            return View(eventreg);
        }
        private List<Event> GetEvents()
        {
            var events = _context.Events.Where(x => !x.IsDelete).ToList();
            return events;
        }
        [HttpPost]
        public JsonResult Index(EventRegistration model)
        {
            var eventreg = new EventRegistration
            {
                Email = model.Email,
                EventDescription = model.EventDescription,
                EventId = model.EventId,
                EventEndDate = Convert.ToDateTime(model.EventEndDate).ToShortDateString(),
                EventStartDate = Convert.ToDateTime(model.EventStartDate).ToShortDateString(),
                EventTitle = model.EventTitle,
                EventType = model.EventType,
                EventVenue = model.EventVenue,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                RegistrationDate = model.RegistrationDate
            };
            _context.EventRegistrations.Add(eventreg);
            _context.SaveChanges();
            return Json(new { Url = "/EventRegistration/RegisterConfirm" });
        }
        public IActionResult RegisterConfirm()
        {
            return View();
        }
    }
}
