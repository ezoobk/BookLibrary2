using BookLibrary2.Application.Services;
using BookLibrary2.Domain.Interfaces;
using BookLibrary2.Domain.Models;

namespace BookLibrary2.Application.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<BookAuthor> GetBookAuthors()
        {
            return _authorRepository.GetBookAuthors();
        }
    }
}
