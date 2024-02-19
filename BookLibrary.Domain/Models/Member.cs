using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary2.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PhoneNum { get; set; }
        public ICollection<RentedBook> RentedBooks { get; set; }
    }
}
