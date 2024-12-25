using System.ComponentModel.DataAnnotations;

namespace Test_.Net.Models;

public class Rental
{
    [Key]
    public int RentalId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int Status { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<RentalDetail> RentalDetails { get; set; }
}