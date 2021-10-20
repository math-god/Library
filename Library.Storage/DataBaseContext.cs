using Library.Storage.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Storage
{
    public class DataBaseContext : DbContext
    {
        protected static DataBaseContext Context;
        protected static readonly object SyncRoot = new object();

        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected DataBaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6K5AE61\\SQLEXPRESS;Database=Library;" +
                                        "Trusted_Connection=True;");
        }
    }
}