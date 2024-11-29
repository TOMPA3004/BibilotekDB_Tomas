using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Borrower
    {
        public int BorrowerID {get; set;}
        public string Custumer {get; set;}
        public int CustumerNr {get; set;}

        
    }
}