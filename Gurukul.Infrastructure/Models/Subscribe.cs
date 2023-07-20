using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class Subscribe
    {
        
        public int Id { get; set; }
        public string Plan { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }= DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string Amount { get; set; }
        public string MagazineId { get; set; }
        public string MagazineTitle { get; set; }
        public List<Magazine> Magazines { get; set; }
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
    }
}
