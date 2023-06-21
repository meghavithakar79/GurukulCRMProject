using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class EventAttendanceController : Controller
    {
        private readonly GurukulDbContext _context;
      
        public EventAttendanceController(GurukulDbContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Permissions.Event.Create)]

        public IActionResult Index(int id)
        {
            EventAttendance eventA = new()
            {
                EventRegistrations = GetUserList(id)
            };
            return View(eventA);

        }
        private List<EventRegistration> GetUserList(int id)
        {
            
            EventRegistration eventRegistration = new EventRegistration();
            var userlist = _context.EventRegistrations.Where(x=>Convert.ToInt32(x.EventId)==id).ToList();
            return userlist;
        }
        [HttpPost]
        public JsonResult Index([FromBody]List<EventAttendance> selectedEvents)
        {
            foreach(var item in selectedEvents)
            {
                _context.EventAttendances.Add(item);
                _context.SaveChanges();
            }
            return Json(new { Url = "/EventRegistration/RegisterConfirm" });
        }
    }
}
