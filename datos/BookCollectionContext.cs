using Microsoft.EntityFrameworkCore;
using BookCollectionAPI.Models;

namespace BookCollectionAPI.Data
{
    public class BookCollectionContext : DbContext
    {
        public BookCollectionContext(DbContextOptions<BookCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
        
            
        
    }
}
