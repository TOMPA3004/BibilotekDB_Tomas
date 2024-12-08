using BibliotekDB.Models;
using System;
using System.Linq;


    public class DeleteBook
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {

            var books = context.Books.ToList();
            if (!books.Any())
            {
                System.Console.WriteLine("No book found ");
            }
            else
            {
                foreach (var bok in books) 
                {
                    System.Console.WriteLine($"Book ID {bok.BookID} Title {bok.Title} ");
                }
            }

            System.Console.Write("Write Book ID you want to delete ");
            if (int.TryParse(Console.ReadLine(), out var bookid))
            {
                var book = context.Books.Find(bookid);
                if (book != null)
                {
                    var authorBook = context.AuthorsBooks.Where(ba => ba.BookID == bookid).ToList();
                    context.AuthorsBooks.RemoveRange(authorBook);

                    context.Books.Remove(book);
                    context.SaveChanges();
                    System.Console.WriteLine("Book has been removed ");
                }
                else
                {
                    Console.WriteLine("Book not found ");
                }
            }
        }
    }
}
public class DeleteLoan
{
   
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            var loans = context.Loans.ToList();
            if (!loans.Any())
            {
                System.Console.WriteLine("Loan not found ");
            }
            else
            {
                foreach (var Borrow in loans) 
                {
                    System.Console.WriteLine($"Loan ID {Borrow.LoanID} Loaners BorrowerName {Borrow.BorrowerName}");
                }
            }

            Console.Write("Write Loan ID to delete ");
            if (int.TryParse(Console.ReadLine(), out var loanId))
            {
                var loan = context.Loans.Find(loanId);
                if (loan != null)
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();
                    Console.WriteLine("Loan has been removed ");
                }
                else
                {
                    Console.WriteLine("Loan ID not found ");
                }
            }
        }
    }
}

public class DeleteAuthor
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            var authors = context.Authors.ToList();

            if (!authors.Any())
            {
                System.Console.WriteLine("No authors found ");
            }
            else
            {
                foreach (var author in authors)
                {
                    System.Console.WriteLine($"Author ID {author.AuthorID} Firstname {author.FirstName} Lastname {author.LastName} ");
                }
            }

            System.Console.Write("Enter Author ID to delete ");
            if (int.TryParse(Console.ReadLine(), out var authorID))
            {
                var author = context.Authors.Find(authorID);
                if (author != null)
                {
                    var bookauth = context.AuthorsBooks.Where(ba => ba.AuthorID == authorID).ToList();
                    context.AuthorsBooks.RemoveRange(bookauth);

                    context.Authors.Remove(author);
                    context.SaveChanges();
                    Console.WriteLine("Author has been deleted ");
                }
            }
            else
            {
                Console.WriteLine("Author hasn`t been found ");
            }
        }
    }
}