using DigitalLibraryBe.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibraryBe.Infrastructure.Context
{
    public class DigitaLibraryDbContext(DbContextOptions<DigitaLibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<LiteraryBook> LiteraryBooks { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasQueryFilter(author => !author.IsDeleted);
            modelBuilder.Entity<Author>().Property(a => a.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<LiteraryBook>().HasQueryFilter(literaryBook => !literaryBook.IsDeleted);
            modelBuilder.Entity<LiteraryBook>().Property(lb => lb.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Author>()
                .HasMany(a => a.LiteraryBooks)
                .WithMany(lb => lb.Authors)
                .UsingEntity<AuthorBook>();

        }
    }
}
