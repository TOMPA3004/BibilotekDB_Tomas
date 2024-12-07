using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Book
    {
        public int BookID {get; set;}
        public string Title {get; set;}      
        public DateOnly ReliseDate {get; set;}
        public bool IsAvailable {get; set;}

        public ICollection<AuthorBook> AuthorsBooks {get;set;}
        public ICollection<Loan> Loans {get; set;}
    }
}
