using BookLibrary2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary2.Infra.Configruation
{
    public class RentedBookConfig : IEntityTypeConfiguration<RentedBook>
    {
        public void Configure(EntityTypeBuilder<RentedBook> builder)
        {
            builder.HasKey(r => r.Id);
            
            builder.HasOne(b => b.book)
                .WithMany(br => br.RentedBooks)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.member)
                .WithMany(mr => mr.RentedBooks)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

