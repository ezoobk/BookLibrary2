using BookLibrary2.Domain.Interfaces;
using BookLibrary2.Domain.Models;
using BookLibrary2.Infra.Data;

namespace BookLibrary2.Infra.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public bool AuthorExists(int id)
        {
            return _context.bookAuthors.Any(c => c.Id == id);
        }

        public bool CreateAuthor(BookAuthor author)
        {
            _context.Add(author);
            return Save();
        }

        public bool DeleteAuthor(BookAuthor author)
        {
            _context.Remove(author);
            return Save();
        }

        public BookAuthor GetAuthor(int id)
        {
            return _context.bookAuthors.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<BookAuthor> GetBookAuthors()
        {
            return _context.bookAuthors.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAuthor(BookAuthor author)
        {
            _context.Update(author);
            return Save();
        }

        Task IAuthorRepository.CreateAuthor(BookAuthor author)
        {
            throw new NotImplementedException();
        }

        Task IAuthorRepository.DeleteAuthor(BookAuthor author)
        {
            throw new NotImplementedException();
        }

        Task<BookAuthor> IAuthorRepository.GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<BookAuthor>> IAuthorRepository.GetBookAuthors()
        {
            throw new NotImplementedException();
        }

        Task IAuthorRepository.Save()
        {
            throw new NotImplementedException();
        }

        Task IAuthorRepository.UpdateAuthor(BookAuthor author)
        {
            throw new NotImplementedException();
        }
    }
}
