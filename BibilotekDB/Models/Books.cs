using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Book
    {
        public int BookID {get; set;}
        public string Title {get; set;}
        public string PublicDate {get; set;}

        
    }
}