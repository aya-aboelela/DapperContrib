using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperContrib.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public List<Book> Books { get; set; }
    }
}