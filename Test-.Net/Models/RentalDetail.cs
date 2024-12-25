using System.ComponentModel.DataAnnotations;

namespace Test_.Net.Models;

public class RentalDetail
{
    [Key]
    public int RentalDetailId { get; set; }
    public int RentalId { get; set; }
    public int ComicBookId { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerDay { get; set; }
    public virtual Rental Rental { get; set; }
    public virtual ComicBook ComicBook { get; set; }
}