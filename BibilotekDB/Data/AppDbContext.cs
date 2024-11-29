using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;

public class AppDbContext : DbContext
{
    public DbSet<Aurthor> Aurthors { get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<Borrower> Borrowers {get; set;}
    public DbSet<Loan> Loan {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BibilotekDB;Trusted_Connection=True;");
    }







}