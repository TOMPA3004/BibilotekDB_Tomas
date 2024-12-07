
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Loan
    {
        public int LoanID {get; set;}
        public int BookID {get; set;}
        
        public DateTime LoanDate {get; set;}
        public DateTime ReturnDate {get; set;}

        public bool Returned {get; set;}
        public string Signature {get; set;}

        public Book Book {get; set;}
    }
}