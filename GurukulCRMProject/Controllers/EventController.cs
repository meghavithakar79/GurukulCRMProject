using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class EventController : Controller
    {
        private readonly GurukulDbContext _context;
        public EventController(GurukulDbContext context)
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
            var events = _context.Events.Where(x => !x.IsDelete).ToList();
            return View(events);
        }
        [HttpGet]
        [Authorize(Permissions.Event.Create)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event model)
        {
            var events = new Event
            {
                EventType = model.EventType,
                Title = model.Title,
                Description = model.Description,
                StartDate = model.StartDate.Date,
                EndDate = model.EndDate.Date,
                Venue = model.Venue
            };
            await _context.Events.AddAsync(events);
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Added Successfully !";
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Permissions.Event.Edit)]
        public IActionResult Edit(int id)
        {
            var events = _context.Events.FirstOrDefault(x => x.Id == id);
            if (events != null)
            {
                var eve = new Event
                {
                    Title = events.Title,
                    Description = events.Description,
                    EventType = events.EventType,
                    StartDate = events.StartDate,
                    EndDate = events.EndDate,
                    Venue= events.Venue
                };
                return View(eve);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Event model)
        {
            var eve = await _context.Events.FindAsync(model.Id);
            if (eve != null)
            {
                eve.Title = model.Title;
                eve.Description = model.Description;
                eve.EventType = model.EventType;
                eve.StartDate = model.StartDate;
                eve.EndDate= model.EndDate;
                eve.Venue = model.Venue;
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Record Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Event.Delete)]
        public IActionResult Delete(int id)
        {
            var eve = _context.Events.Find(id);
            eve.IsDelete = true;
            _context.SaveChanges();
            TempData["ResultOk"] = "Record Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
