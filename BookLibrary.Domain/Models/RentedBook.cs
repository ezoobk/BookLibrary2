using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary2.Domain.Models
{
    public class RentedBook
    {
        public int Id { get; set; }
        public int ReceiptNum { get; set; }

        public int BookId { get; set; }
        public Book book { get; set; }
        public int MemberId { get; set; }
        public Member member { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime RentDue { get; set; }

        public bool Returnd { get; set; }
    }
}
