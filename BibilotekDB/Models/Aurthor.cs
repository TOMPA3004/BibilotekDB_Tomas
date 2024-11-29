using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Net;
using Microsoft.Identity.Client;

namespace BibliotekDB.Models
{
    public class Aurthor
    {
        public int AurthorId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        
        public Book BookID {get; set;}
    }
}