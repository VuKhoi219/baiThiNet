using System.ComponentModel.DataAnnotations;

namespace Test_.Net.Models;

public class ComicBook
{
    [Key]
    public int ComicBookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal PricePerDay { get; set; }
}