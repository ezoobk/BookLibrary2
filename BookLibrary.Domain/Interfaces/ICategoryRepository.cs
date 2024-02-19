using BookLibrary2.Domain.Models;

namespace BookLibrary2.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<BookCategory> GetBookCategories();
        BookCategory GetCategory(int categoryid);
        bool CategoryExists(int categoryid);
        bool CreateCategory(BookCategory category);
        bool Save();
    }
}
