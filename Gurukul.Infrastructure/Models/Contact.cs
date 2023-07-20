using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]

        [RegularExpression(@"^(A|B|AB|O|a|b|ab|o)[+-]$", ErrorMessage = "Not a valid BloodGroup")]
        public string BloodGroup { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(?([+][0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{5})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"([0-9]{6})", ErrorMessage = "Not a valid pincode")]
        public string ZipCode { get; set; }
        [Required]
        public string OccupationType { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string EducationLevel { get; set; }

        public bool IsDelete { get; set; }
        public ICollection<Magazine> Magazines { get; set; }
    }
}
