using LibraryApp.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DAL
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() { }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Thesis> Thesis { get; set; }
        public DbSet<ResearchScholar> ResearchScholars { get; set; }
    }
}
