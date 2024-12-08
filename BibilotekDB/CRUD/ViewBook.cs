using System;
using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;

public class ViewBook
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            var books = context.Books.Include(b => b.AuthorsBooks)
                .ThenInclude(b => b.Author)
                .ToList();

            if (books.Any())
            {

                foreach (var book in books)
                {
                    System.Console.WriteLine($"Book Title {book.Title} ");
                    foreach (var author in book.AuthorsBooks)
                    {
                        System.Console.WriteLine($"Author ID {author.AuthorID} Author Name {author.Author.FirstName} {author.Author.LastName}");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("They got no relation ");
            }
        }
    }
}