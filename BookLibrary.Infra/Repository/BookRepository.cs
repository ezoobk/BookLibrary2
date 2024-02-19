using BookLibrary2.Domain.Interfaces;
using BookLibrary2.Domain.Models;
using BookLibrary2.Dto;
using BookLibrary2.Infra.Data;

namespace BookLibrary2.Infra.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooks()
        {
            return _context.books.OrderBy(p => p.Id).ToList();
        }
        public Book GetBook(int id)
        {
            return _context.books.Where(p => p.Id == id).FirstOrDefault();
        }
        public bool BookExists(int? bookId, string? bookName)
        {
            if (bookName == null & bookId != null)
            {
                return _context.books.Any(p => p.Id == bookId);
            }
            else if (bookId == null & bookName != null)
            {
                return _context.books.Any(n => n.Name == bookName);
            }

            return false;
        }

        public ICollection<Book> GetAvailableBooks()
        {
            return _context.books.Where(p => p.Qnantity > 0).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool InsertBook(int categoryId, int authorId, BookDto createBook)
        {
            var newBook = new Book
            {
                Name = createBook.bookName,
                ReleaseDate = createBook.releaseDate,
                Qnantity = createBook.quantity,
                Category = _context.bookCategories.FirstOrDefault(c => c.Id == categoryId),
                Author = _context.bookAuthors.FirstOrDefault(a => a.Id == authorId)
            };

            _context.Add(newBook);
            return Save();
        }

        public bool UpdateBook(int bookId, BookDto bookDto)
        {
            var book = _context.books.FirstOrDefault(p => p.Id == bookId);

            book.Name = bookDto.bookName;
            book.ReleaseDate = bookDto.releaseDate;
            book.Qnantity = bookDto.quantity;

            return Save();
        }

        public bool DeleteBook(int bookId)
        {

            if (!BookExists(bookId, null))
                return false;

            var book = _context.books.FirstOrDefault(p => p.Id == bookId);

            _context.Remove(book);

            return Save();

        }

        public ICollection<Book> GetAuthorBooks(BookAuthor author)
        {
            return _context.books.Where(p => p.Author == author).ToList();
        }
    }
}
