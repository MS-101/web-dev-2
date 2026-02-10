using Mansus.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace Mansus.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<PaperBook> PaperBooks { get; set; }

        public DbSet<EBook> EBooks { get; set; }

        public DbSet<AudioBook> AudioBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            int authorA_id = 1;
            int authorB_id = 2;

            modelBuilder.Entity<Author>().HasData(
                new { Id = authorA_id, Name = "Author A" },
                new { Id = authorB_id, Name = "Author B" }
            );

            var categoryA_id = 1;
            var categoryB_id = 2;
            var categoryC_id = 3;


            modelBuilder.Entity<BookCategory>().HasData(
                new { Id = categoryA_id, Name = "Book Category A", ParentId = (int?)null },
                new { Id = categoryB_id, Name = "Book Category B", ParentId = categoryA_id },
                new { Id = categoryC_id, Name = "Book Category C", ParentId = categoryA_id }
            );

            var bookA_id = 1;
            var bookB_id = 2;

            modelBuilder.Entity<Book>().HasData(
                new { Id = bookA_id, Name = "Book A", Description = "Description of book A.", BookCategoryId = categoryB_id },
                new { Id = bookB_id, Name = "Book B", Description = "Description of book B.", BookCategoryId = categoryC_id }
            );

            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = authorA_id, BooksId = bookA_id },
                new { AuthorsId = authorA_id, BooksId = bookB_id },
                new { AuthorsId = authorB_id, BooksId = bookA_id }
            );

            var publisherA_id = 1;
            var publisherB_id = 2;

            modelBuilder.Entity<Publisher>().HasData(
                new { Id = publisherA_id, Name = "Publisher A" },
                new { Id = publisherB_id, Name = "Publisher B" }
            );

            var languageEN_id = 1;
            var languageDE_id = 2;

            modelBuilder.Entity<Language>().HasData(
                new { Id = languageEN_id, Name = "English" },
                new { Id = languageDE_id, Name = "German" }
            );

            modelBuilder.Entity<PaperBook>().HasData(
                new
                {
                    Id = 1,
                    Name = "Paperbook A",
                    Description = "Description of paper book A.",
                    Price = 10.00M,
                    Discount = 0M,
                    BookId = bookA_id,
                    PublisherId = publisherA_id,
                    LanguageId = languageEN_id
                },
                new {
                    Id = 2,
                    Name = "Papierbuch A",
                    Description = "Beschreibung des Papierbuch A.",
                    Price = 10.00M,
                    Discount = 0M,
                    BookId = bookA_id,
                    PublisherId = publisherB_id,
                    LanguageId = languageDE_id
                },
                new
                {
                    Id = 3,
                    Name = "Paperbook B",
                    Description = "Description of paper book B.",
                    Price = 15.00M,
                    Discount = 0M,
                    BookId = bookB_id,
                    PublisherId = publisherA_id,
                    LanguageId = languageEN_id
                }
            );

            modelBuilder.Entity<EBook>().HasData(
                new
                {
                    Id = 4,
                    Name = "E-book A",
                    Description = "Description of e-book A.",
                    Price = 10.00M,
                    Discount = 0M,
                    BookId = bookA_id,
                    PublisherId = publisherA_id,
                    LanguageId = languageEN_id
                },
                new
                {
                    Id = 5,
                    Name = "E-book B",
                    Description = "Description of E-book B.",
                    Price = 10.00M,
                    Discount = 0M,
                    BookId = bookB_id,
                    PublisherId = publisherA_id,
                    LanguageId = languageEN_id
                }
            );
        }
    }
}
