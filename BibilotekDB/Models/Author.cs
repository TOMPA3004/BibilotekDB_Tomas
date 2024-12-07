using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Net;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Author
    {
        public int AuthorID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        
        public ICollection<AuthorBook> AuthorBook {get; set;}
    }
}