namespace BookLibrary2.Application.Services
{
    public interface IAuthorService
    {
        List<Domain.Models.BookAuthor> GetBookAuthors();
    }
}
