using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary2.Domain.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> books { get; set; }

    }
}
