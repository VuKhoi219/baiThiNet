using Microsoft.EntityFrameworkCore;
using Test_.Net.Models;

namespace Test_.Net.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(
        DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId);

        modelBuilder.Entity<RentalDetail>()
            .HasOne(rd => rd.Rental)
            .WithMany(r => r.RentalDetails)
            .HasForeignKey(rd => rd.RentalId);

        modelBuilder.Entity<RentalDetail>()
            .HasOne(rd => rd.ComicBook)
            .WithMany()
            .HasForeignKey(rd => rd.ComicBookId);
    }
    
    public DbSet<ComicBook> ComicBooks { get; set; }
}