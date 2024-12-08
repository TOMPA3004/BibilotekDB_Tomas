using System;
using Microsoft.EntityFrameworkCore;
using BibliotekDB.Models;

public class BibelotekList
{
    public static void Run()
    {
        using (var context = new AddDbContext())
        {
            while (true)
            {
                System.Console.WriteLine("List");
                System.Console.WriteLine("Do you to see listYes/No");
                var _input = Console.ReadLine();
                if (_input == "No")
                {
                    System.Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                    return;
                }
                
                else if (_input == "Yes")
                {
                    System.Console.WriteLine("\n1. View Relationship");
                    System.Console.WriteLine("2. View List Book");
                    System.Console.WriteLine("3. View List Loan");
                    System.Console.WriteLine("4. Go To Menu");
                

                    var _menuInput = Console.ReadLine();
                    switch (_menuInput)
                    {
                        case "1":
                            ViewBook.Run();
                            break;
                        case "2":
                            ListBook.Run();
                            break;
                        case "3":
                            ListLoan.Run();
                            break;
                        case "4":
                            System.Console.WriteLine("To go back press any key ");
                            Console.ReadLine();
                            return;
                        default:
                            System.Console.WriteLine("Select between 1 - 4 ");  
                            Console.ReadLine();                      
                            break; 
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid Try again 1 - 4 ");
                    Console.ReadLine();       
                }
            }
        }
    }

public class ListBook
{
    public static void Run()
    {
        using(var context = new AddDbContext())
        {
            var Books = context.Books.Include(ba => ba.AuthorsBooks)
                .ThenInclude(AuthorsBook => AuthorsBook.Author)
                .ToList();
            
            foreach (var Book in Books)
            {
                System.Console.WriteLine($"\nBook ID {Book.BookID} Book Title {Book.Title} {Book.ReliseDate} ");
                foreach (var author in Book.AuthorsBooks)
                {
                    System.Console.WriteLine($"Author ID {author.AuthorID} Author {author.Author.FirstName} {author.Author.LastName} ");
                }
            }
        }
    }
}
    public class ListLoan
    {
        public static void Run()
        {

            using (var context = new AddDbContext())
            {
                var loans = context.Loans.Include(l => l.Book)
                    .Where(l => l.IsReturn  == false)
                    .ToList();

                if (!loans.Any())
                {
                    System.Console.WriteLine("There are no loan books ");
                }
                else
                {
                    foreach (var loan in loans)
                    {
                        System.Console.WriteLine($"\nBook: {loan.Book.Title}");
                        System.Console.WriteLine($"Has been returnned {loan.IsReturn }");
                        System.Console.WriteLine($"Borrower Name {loan.BorrowerName }");
                                                
                    }

                }
            }
        }
    }
}
