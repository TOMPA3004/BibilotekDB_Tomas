using System;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using BibliotekDB.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

class Program
{
    
    static void Main(string[] args)
    {   
        Seedo.Run();
        Console.WriteLine("Welcome To The Bibilotek\n");
        int menuSel = 0;
        do
        {
            menuSel = MenuSelect();
            Menu(menuSel);
        }
        while (menuSel != 9);
    }
    private static int MenuSelect()
    {
        int menuSel = 0;
        Console.WriteLine("========== MENU ==========");
        Console.WriteLine("1. Create a Book");
        Console.WriteLine("2. Create an Author");
        Console.WriteLine("3. Delete a Book");
        Console.WriteLine("4. Delete an Author");
        Console.WriteLine("5. Delete a Loan Record");
        Console.WriteLine("6. Manage Book Loans and Returns");
        Console.WriteLine("7. Add a Relationship Between Author and Book");
        Console.WriteLine("8. Display All Records");
        Console.WriteLine("9. Exit");
        Console.WriteLine("===========================");
        try
        {
            menuSel = Convert.ToInt32(Console.ReadLine());
            if (menuSel < 1 || menuSel > 9)
            {
                Console.WriteLine("Please select Between 1 - 9");
                Console.ReadLine();
                return MenuSelect();
            }
        }
        catch
        {
            System.Console.WriteLine("Please select between 1 - 9");
            Console.ReadLine();
            return MenuSelect(); 
        }
        return menuSel;
    }
    private static void Menu(int menuSel)
    {
        switch (menuSel)
        {
            case 1:
                CreateBook.Run();
                break;
            case 2:
                CreateAuthor.Run();
                break;
            case 3:
                DeleteBook.Run();
                break;
            case 4:
                DeleteAuthor.Run();
                break;
            case 5:
                DeleteLoan.Run();
                break;
            case 6:
                ReturnLoans.Run();
                break;
            case 7:
                AddRelationship.Run();
                break;
            case 8:
                BibelotekList.Run();
                break;
             case 9:
                System.Console.WriteLine("Welcome back anytime!");
                menuSel = 0;   
                return;
            default:
                System.Console.WriteLine("Not a valid input!");
                Console.ReadLine();
                break;
        }
    }
}