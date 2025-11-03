using Microsoft.EntityFrameworkCore;

using Mansus.Server.Models;


namespace Mansus.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
                new { Id = 1, Name = "Abdul Alhazred" },
                new { Id = 2, Name = "Eibon" }
            );

            modelBuilder.Entity<Book>().HasData(
                new { Id = 1, Title = "Necronomicon", Description = "The very act of studying the text is inherently dangerous, as those who attempt to master its arcane knowledge generally meet terrible ends." },
                new { Id = 2, Title = "Book of Eibon", Description = "The Book of Eibon, that strangest and rarest of occult forgotten volumes ... is said to have come down through a series of manifold translations from a prehistoric original written in the lost language of Hyperborea." }
            );

            modelBuilder.Entity("AuthorBook").HasData(
                new { AuthorsId = 1, BooksId = 1 },
                new { AuthorsId = 2, BooksId = 2 }
            );
        }
    }
}
