using System;
using Microsoft.EntityFrameworkCore.Storage.Json;
using BibliotekDB.Models;

public class CreateBook
{
   
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            System.Console.WriteLine("Add a new Book to List Test");

            System.Console.WriteLine("Enter Title");
            var _title = Console.ReadLine()?.Trim();

            System.Console.WriteLine("Enter Release Date YYYY-MM-DD ");
            var _reliseDate = Console.ReadLine();
            if (!DateOnly.TryParse(_reliseDate, out DateOnly reliseDate))
            {
                System.Console.WriteLine("Not a valid input! Try again");
                return;
            }

            System.Console.WriteLine("Ready to loan");
            bool _isavailable = true;

            var _book = new Book
            {
                Title = _title,
                ReliseDate = reliseDate,
                 IsAvailable = _isavailable
            };
            context.Books.Add(_book);
            context.SaveChanges();
            System.Console.WriteLine($"{_title} Book have been created"); 
        }
    }

}    

public class CreateAuthor
{


    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            System.Console.WriteLine("\nAdd new Author\n");
            Console.ResetColor();

            System.Console.WriteLine("Write First Name: ");
            var _firstName = Console.ReadLine()?.Trim();
            System.Console.WriteLine("Write Last Name: ");
            var _lastName = Console.ReadLine()?.Trim();

            var _author = new Author 
            {
                FirstName = _firstName,
                LastName = _lastName,
            };

            context.Authors.Add(_author);
            context.SaveChanges();
            System.Console.WriteLine($"{_firstName} {_lastName} Author have been created\n");
        }
    }
}