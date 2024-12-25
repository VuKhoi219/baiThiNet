using System.ComponentModel.DataAnnotations;

namespace Test_.Net.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    
    public DateTime RegisterDate { get; set; }
    public IEnumerable<Rental>? Rentals { get; set; }
}