using BookLibrary2.Domain.Models;

namespace BookLibrary2.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<BookAuthor>> GetBookAuthors();
        Task<BookAuthor> GetAuthor(int id);
        bool AuthorExists(int id);
        Task CreateAuthor(BookAuthor author);
        Task UpdateAuthor(BookAuthor author);
        Task DeleteAuthor(BookAuthor author);
        Task Save();
    }
}
