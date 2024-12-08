using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;

public class AddRelationship
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            var books = context.Books.ToList();

            if(books.Any())
            {
            foreach (var book in books)
            {
                System.Console.WriteLine($"Book ID {book.BookID} Title {book.Title} ");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no available ");
            } 

        var Authors = context.Authors.ToList();
        
            if(Authors.Any())
            {
            foreach (var author in Authors)
            {
                System.Console.WriteLine($"Author ID {author.AuthorID} Name {author.FirstName} {author.LastName} ");
            }
            }
            else 
            {
                System.Console.WriteLine("There is no available author ");
            } 

            System.Console.Write("Enter Book ID ");

            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                System.Console.WriteLine("Invalid BookID ");
            }

            System.Console.Write("Enter Author ID ");

            if (!int.TryParse(Console.ReadLine(), out var authorID))
            {
                System.Console.WriteLine("Invalid Author ID ");
            }

            var authorBook = new AuthorBook
            {
                BookID = bookID, AuthorID = authorID
            };

            context.AuthorsBooks.Add(authorBook);
            context.SaveChanges();
            System.Console.WriteLine("Saved Succesfully ");
            
        }
    }
}
