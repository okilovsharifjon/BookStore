using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataAccess
{
    public class Book
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; } 
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required string Image { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}
