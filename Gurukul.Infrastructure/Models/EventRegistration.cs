using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class EventRegistration
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(?([+][0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{5})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }= DateTime.Today;
        [JsonPropertyName("eventId")]
        public string EventId { get; set; }
        [JsonPropertyName("title")]
        public string EventTitle { get; set; }
        [JsonPropertyName("description")]
        public string EventDescription { get; set; }
        [JsonPropertyName("eventType")]
        public string EventType { get; set; }
        [JsonPropertyName("startDate")]
        public string EventStartDate { get; set; }
        [JsonPropertyName("endDate")]
        public string EventEndDate { get; set; }
        [JsonPropertyName("venue")]
        public string EventVenue { get; set; }
        public List<Event> events { get; set; }
    }
}
