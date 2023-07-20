using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
        public IActionResult Index(IFormCollection form)
        {
            string firstName = form["FirstName"];
            string lastName = form["LastName"];
            string email = form["Email"];
            string phoneNumber = form["PhoneNumber"];
            string selectedEventsJson = form["selectedEventsInput"];

            List<EventRegistration> selectedEvents = JsonSerializer.Deserialize<List<EventRegistration>>(selectedEventsJson);

            foreach (var selectedEvent in selectedEvents)
            {
                string eventId = selectedEvent.EventId;
                string eventType = selectedEvent.EventType;
                string title = selectedEvent.EventTitle;
                string description = selectedEvent.EventDescription;
                string startDate = selectedEvent.EventStartDate;
                string endDate = selectedEvent.EventEndDate;
                string venue = selectedEvent.EventVenue;

                var eventreg = new EventRegistration
                {
                    Email = email,
                    EventDescription = description,
                    EventId = eventId,
                    EventEndDate = endDate,
                    EventStartDate = startDate,
                    EventTitle = title,
                    EventType = eventType,
                    EventVenue = venue,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    RegistrationDate = DateTime.Now
                };
                _context.EventRegistrations.Add(eventreg);
                _context.SaveChanges();
            }
            return View(nameof(RegisterConfirm));
        }
        public IActionResult RegisterConfirm()
        {
            return View();
        }
    }
}
