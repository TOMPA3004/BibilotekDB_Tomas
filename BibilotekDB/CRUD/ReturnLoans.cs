using BibliotekDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Azure.Core.Pipeline;


public class ReturnLoans
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            System.Console.WriteLine("\nLoan or Return book");
            System.Console.WriteLine("1. Loan Book");
            System.Console.WriteLine("2. Return Book");
            System.Console.WriteLine("3. Go back");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddLoans();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "4":
                    System.Console.WriteLine("Press any key to go back ");
                    Console.ReadLine();
                    return;
            }
        }
    }



    public static void AddLoans()
    {
        using (var context = new AddDbContext())
        {

            System.Console.WriteLine("\nBooks Available\n");
            var books = context.Books.Include(ba => ba.AuthorsBooks) 
                .ThenInclude(ba => ba.Author)
                .ToList();

            if (!books.Any())
            {
                Console.WriteLine("There is no books to loan ");
                return;
            }

            foreach (var boks in books)
            {
                Console.WriteLine($"Book ID {boks.BookID}, Title {boks.Title} Available {(boks.IsAvailable ? "Yes" : "No")}\n");
            }


            Console.Write("Write borrower's Name ");
            var borrower = Console.ReadLine();

            Console.Write("Enter Book ID ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("The book ID is Invalid ");
                return;
            }

            var book = context.Books.Find(bookID);
            if (book == null)
            {
                Console.WriteLine("Book not found ");
                return;
            }

            if (!book.IsAvailable)
            {
                System.Console.WriteLine(" The book is not available ");
                return;
            }
            var loan = new Loan
            {
                BookID = bookID,
                BorrowerName = borrower,
                LoanDate = DateTime.Now,
                IsReturn = false
            };

            context.Loans.Add(loan);
            context.SaveChanges();

            Console.WriteLine($"Loan added {bookID} borrower {borrower} ");
        }
    }


    public static void ReturnBook()
    {
        using (var context = new AddDbContext())
        {
            Console.Write("Write borrower's Name ");
            var borrower = Console.ReadLine();

            Console.Write("Write BookID to return ");
            if (!int.TryParse(Console.ReadLine(), out var bookID))
            {
                Console.WriteLine("There is no Book ID matching ");
                return;
            }

            var loan = context.Loans
                .FirstOrDefault(l => l.BorrowerName == borrower && l.BookID == bookID && !l.IsReturn);

            if (loan == null)
            {
                Console.WriteLine("No loan has been registerd borrower ");
                return;
            }

            loan.IsReturn = true;
            loan.ReturnDate = DateTime.Now;


            var book = context.Books.Find(bookID);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            context.SaveChanges();
            Console.WriteLine($"borrower {borrower} has returned {bookID} ");
        }
    }
}