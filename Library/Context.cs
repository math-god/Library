using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class Context : DbContext
    {
        private static Context _context;
        private static object syncRoot = new object();
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Reader> Readers { get; set; }
        
        private Context()
        {
            Database.EnsureCreated();
        }

        public static Context GetContext()
        {
            if (_context != null) return _context;
            lock (syncRoot)
            {
                _context ??= new Context();
            }
            return _context;
        }  
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6K5AE61\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
        }
    }
}