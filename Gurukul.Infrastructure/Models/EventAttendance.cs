using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class EventAttendance
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public List<EventRegistration> EventRegistrations { get; set; }
    }
}
