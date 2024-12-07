
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

        public bool IsReturn {get; set;}
        public string BorrowerName {get; set;}

        public Book Book {get; set;}
    }
}