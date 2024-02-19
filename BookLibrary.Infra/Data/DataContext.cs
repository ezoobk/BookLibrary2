using Microsoft.EntityFrameworkCore;
using BookLibrary2.Domain.Models;

namespace BookLibrary2.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> books { get; set; }
        public DbSet<BookAuthor> bookAuthors { get; set; }
        public DbSet<BookCategory> bookCategories { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<RentedBook> rentedBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=Ezo;Initial Catalog=BookLibraryDb2;User ID=Ezoo;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
