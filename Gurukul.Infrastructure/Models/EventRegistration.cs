using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class EventRegistration
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }= DateTime.Today;
        public string EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string EventType { get; set; }
        public string EventStartDate { get; set; }
        public string EventEndDate { get; set; }
        public string EventVenue { get; set; }
        public List<Event> events { get; set; }
    }
}
