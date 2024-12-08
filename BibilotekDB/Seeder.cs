using BibliotekDB.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class Seedo
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            if(!context.Authors.Any())
            {
                var author1 = new Author
                {
                    FirstName = "Naruto",
                    LastName = "Uzumaki",
                };

                var author2 = new Author()
                {
                    FirstName = "Ichigo",
                    LastName = "Kurosaki",
                };
                context.Authors.Add(author1);
                context.Authors.Add(author2);
                context.SaveChanges();
                Console.WriteLine("Seed added succesfully for Author");
            }
            else
            {
                Console.WriteLine("Authors already deployed");
            }

            if(!context.Books.Any())
            {
                var book1 = new Book
                {
                    Title = "Naruto",
                    ReliseDate = new DateOnly(2012,7,20),
                    IsAvailable = true
                };

                var book2 = new Book
                {
                    Title = "Bleach",
                    ReliseDate = new DateOnly(2000, 7, 30),
                    IsAvailable = true
                };
                
                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges();
                Console.WriteLine("Books added succesfully for Author");
            }

            if (!context.AuthorsBooks.Any())
            {
                var book1 = context.Books.First(b => b.Title == "Naruto");
                var author1 = context.Authors.First(a => a.FirstName == "Naruto" && a.LastName == "Uzumaki");
 
                var book2 = context.Books.First(b => b.Title == "Bleach");
                var author2 = context.Authors.First(a => a.FirstName == "Ichigo" && a.LastName == "Kurosaki");
 
                context.AuthorsBooks.Add(new AuthorBook { BookID = book1.BookID, AuthorID = author1.AuthorID });
                context.AuthorsBooks.Add(new AuthorBook { BookID = book2.BookID, AuthorID = author2.AuthorID });
 
                context.SaveChanges();
                Console.WriteLine("Both seeds added sucessfully");
            }
 
        }
    }
}