using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Loan 
    {
        public int LoanID {get; set;}
        public string BorrowerDate {get; set;}
        public string ReturnDate {get; set;}

        
        public Borrower BorrowerID {get; set;} // kan vara problem med det frammåt glöm ej!!
        public Book BookID {get; set;}
    }
}