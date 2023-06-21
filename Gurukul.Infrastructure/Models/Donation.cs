using System.ComponentModel.DataAnnotations;

namespace Gurukul.Infrastructure.Models;

public class Donation
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Branch { get; set; }
    public string Trust { get; set; }
    public string paymentMethod { get; set; }
    public string Amount { get; set; }
    [DataType(DataType.Date)]
    public DateTime DonationDate { get; set; }= DateTime.Now;
    public bool IsDeleted { get; set; }

}
