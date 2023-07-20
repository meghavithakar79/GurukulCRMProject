using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gurukul.Infrastructure.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB {  get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^\(?([+][0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{5})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string Board { get; set; }
        [Required]
        public string Medium { get; set; }
        [DataType(DataType.Date)]
        public DateTime Enrollment_Date { get; set; }= DateTime.Now;
        [Required]
        public string CGPA { get; set; }
        [Required]
        public string Percentage { get; set; }
    }
}
