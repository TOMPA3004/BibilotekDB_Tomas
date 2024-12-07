using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Identity.Client;
namespace BibliotekDB.Models
{
    public class AuthorBook
    {
        public int AuthorID {get; set;}
        public int BookID {get; set;}
        public int AuthorBookID {get; set;}
        public Author Author {get; set;}
        public Book Book {get; set;}
    }
}