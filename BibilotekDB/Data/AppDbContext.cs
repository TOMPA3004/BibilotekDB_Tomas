using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;
public class AppDbContext : DbContext
{
    public DbSet<Aurthor> Aurthors {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<AurthorBook> AurthorsBooks {get; set;}
    public DbSet<Loan> Loans {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BibelotekDB;Trusted_Connection=True;");
    }

}




