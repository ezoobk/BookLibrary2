using BookLibrary2.Domain.Models;
using BookLibrary2.Dto;

namespace BookLibrary2.Domain.Interfaces
{
    public interface IRentedBookRepository
    {
        ICollection<RentedBook> GetRentedBooks();
        RentedBook GetRentedBook(int receipt);
        ICollection<rentDto> GetRentedBooksByMember(int memberId);
        ICollection<rentDto> GetMembersByRentedBooks(int bookId);
        ICollection<rentDto> GetRentDueBooks();
        bool rentBook(RentedBook rentedBook);
        bool returnBook(RentedBook rentedBook);
        bool bookExists(int bookId);
        bool memberExists(int bookId);
        bool RentedBookExists(int? receiptNum, int? memberId, int? bookId);
        bool rentReturnBook(int bookId, int receiptNum);
        int getReceiptNum();
        bool Save();

    }
}
