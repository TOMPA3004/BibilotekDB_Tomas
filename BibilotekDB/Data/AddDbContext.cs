using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;
public class AddDbContext : DbContext
{
    public DbSet<Author> Authors {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<AuthorBook> AuthorsBooks {get; set;}
    public DbSet<Loan> Loans {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BibelotekDB;Trusted_Connection=True;");
    }

}




