using BookLibrary2.Domain.Interfaces;
using BookLibrary2.Domain.Models;
using BookLibrary2.Dto;
using BookLibrary2.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary2.Infra.Repository
{
    public class RentedBookRepository : IRentedBookRepository
    {
        private readonly DataContext _context;

        public RentedBookRepository(DataContext contxet)
        {
            _context = contxet;
        }

        public bool bookExists(int bookId)
        {
            return _context.books.Any(b => b.Id == bookId && b.Qnantity > 0);
        }

        public ICollection<rentDto> GetMembersByRentedBooks(int bookId)
        {
            var result = _context.books
                .Join(_context.rentedBooks
                .Where(r => r.BookId == bookId && r.Returnd == false),
                b => b.Id,
                r => r.BookId,
                (b, r) => new { Book = b, RentedBook = r })
                .Join(_context.members,
                joinedTables => joinedTables.RentedBook.MemberId,
                m => m.Id,
                (joinedTables, m) => new rentDto
                {
                    Receipt = joinedTables.RentedBook.ReceiptNum,
                    FullName = m.FullName,
                    BookName = joinedTables.Book.Name,
                    RentDate = joinedTables.RentedBook.RentDate,
                    RentDue = joinedTables.RentedBook.RentDue,
                })
                .ToList();

            return result;

        }

        public int getReceiptNum()
        {
            int maxReceipt = 0;

            var books = GetRentedBooks();

            if (books.Any())
            {
                maxReceipt = books.Max(n => n.ReceiptNum);

                if (maxReceipt == 0)
                    maxReceipt = 1;
                else
                    maxReceipt = maxReceipt + 1;
            }
            return maxReceipt;
        }

        public ICollection<rentDto> GetRentDueBooks()
        {
            return _context.rentedBooks
                .Where(r => r.RentDue < DateTime.Now)
                .Select(r => new rentDto
                {
                    Receipt = r.ReceiptNum,
                    FullName = r.member.FullName,
                    BookName = r.book.Name,
                    RentDate = r.RentDate,
                    RentDue = r.RentDue,
                })
                .ToList();
        }

        public RentedBook GetRentedBook(int receiptNum)
        {
            return _context.rentedBooks.Where(r => r.ReceiptNum == receiptNum).FirstOrDefault();
        }

        public ICollection<RentedBook> GetRentedBooks()
        {
            return _context.rentedBooks.Where(r => r.Returnd == false).ToList();
        }

        public ICollection<rentDto> GetRentedBooksByMember(int memberId)
        {
            var result = _context.members
                .Join(_context.rentedBooks
                .Where(r => r.MemberId == memberId && r.Returnd == false),
                m => m.Id,
                r => r.MemberId,
                (m, r) => new { Member = m, RentedBook = r })
                .Join(_context.books,
                joinedTables => joinedTables.RentedBook.BookId,
                b => b.Id,
                (joinedTables, b) => new rentDto
                {
                    Receipt = joinedTables.RentedBook.ReceiptNum,
                    FullName = joinedTables.Member.FullName,
                    BookName = b.Name,
                    RentDate = joinedTables.RentedBook.RentDate,
                    RentDue = joinedTables.RentedBook.RentDue,
                })
                .ToList();

            return result;
        }

        public bool memberExists(int memberId)
        {
            return _context.members.Any(b => b.Id == memberId);
        }

        public bool rentBook(RentedBook rentedBook)
        {
            _context.Add(rentedBook);
            return Save();
        }

        public bool RentedBookExists(int? receiptNum, int? memberId, int? bookId)
        {
            if (receiptNum == null & memberId != null && bookId == null)
            {
                return _context.rentedBooks.Any(r => r.MemberId == memberId && r.Returnd == false);
            }
            else if (receiptNum == null & memberId == null && bookId != null)
            {
                return _context.rentedBooks.Any(r => r.BookId == bookId && r.Returnd == false);
            }
            else if (receiptNum == null & memberId == null & bookId == null)
            {
                return _context.rentedBooks.Any(r => r.Returnd == false);
            }
            else
            {
                return _context.rentedBooks.Any(r => r.ReceiptNum == receiptNum && r.MemberId == memberId && r.Returnd == false);
            }
        }

        public bool rentReturnBook(int bookId, int receiptNum)
        {
            var book = _context.books.Where(b => b.Id == bookId).FirstOrDefault();

            if (receiptNum != 0)
            {
                book.Qnantity = book.Qnantity + 1;

                var rent = _context.rentedBooks.Where(r => r.ReceiptNum == receiptNum).FirstOrDefault();
                rent.Returnd = true;
            }
            else
                book.Qnantity = book.Qnantity - 1;


            return Save();

        }

        public bool returnBook(RentedBook rentedBook)
        {
            rentedBook.Returnd = true;
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
