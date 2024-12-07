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
       
        Console.WriteLine("Welcome To The Bibilotek\n");
        int menuSel = 0;
        do
        {
            menuSel = MenuSelect();
            Menu(menuSel);
        }
        while (menuSel != 7);
    }
    private static int MenuSelect()
    {
        int menuSel = 0;
        Console.WriteLine("Menu Selection");
        Console.WriteLine("1. Create Book, ");
        Console.WriteLine("2. Create Author");
        Console.WriteLine("3. Delete Book");
        Console.WriteLine("4. Delete Author");
        Console.WriteLine("5. Delete Loan");
        Console.WriteLine("6. Loan and return Book");
        Console.WriteLine("7. Update Book, Author");
        Console.WriteLine("8. Add Reltionship from Author to Book.");
        Console.WriteLine("9. List");
        Console.WriteLine("10. Quit");
        try
        {
            menuSel = Convert.ToInt32(Console.ReadLine());
            if (menuSel < 1 || menuSel > 10)
            {
                Console.WriteLine("Select Between 1 - 10");
                Console.ReadLine();
                return MenuSelect();
            }
        }
        catch
        {
            System.Console.WriteLine("Select between 1 - 10");
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
            test.Run();
                break;
            case 2:
                test.Run();
                break;
            case 3:
                test.Run();
                break;
            case 4:
                test.Run();
                break;
            case 5:
                test.Run();
                break;
            case 6:
                test.Run();
                break;
            case 7:
                test.Run();
                break;
            case 8:
                test.Run();
                break;
            case 9:
                test.Run();
                break;
            case 10:
                System.Console.WriteLine("Goodbye");
                menuSel = 0;   
                return;
            default:
                System.Console.WriteLine("Not a valid input!");
                Console.ReadLine();
                break;
        }
    }
}