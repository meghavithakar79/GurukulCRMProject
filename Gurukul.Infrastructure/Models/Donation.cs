using System.ComponentModel.DataAnnotations;

namespace Gurukul.Infrastructure.Models;

public class Donation
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
    [Required]
    public string Address { get; set; }
    [Required]
    public string Branch { get; set; }
    [Required]
    public string Trust { get; set; }
    [Required]
    public string paymentMethod { get; set; }
    [Required]
    [MinLength(2,ErrorMessage ="The amount should be of minimum 2 digits")]
    public string Amount { get; set; }
    [DataType(DataType.Date)]
    public DateTime DonationDate { get; set; }= DateTime.Now;
    public bool IsDeleted { get; set; }

}
