using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary2.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Qnantity { get; set; }
        public BookAuthor Author { get; set; }
        public BookCategory Category { get; set; }
        public ICollection<RentedBook> RentedBooks { get; set; }
    }
}
