using BookLibrary2.Domain.Models;
using BookLibrary2.Dto;

namespace BookLibrary2.Domain.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        ICollection<Book> GetAvailableBooks();
        ICollection<Book> GetAuthorBooks(BookAuthor Author);
        Book GetBook(int id);
        bool BookExists(int? bookId, string? bookName);
        bool InsertBook(int categoryId, int authorId, BookDto createBook);
        bool UpdateBook(int bookId, BookDto book);
        bool DeleteBook(int bookId);
        bool Save();
    }
}
