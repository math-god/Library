using Library.Models;

namespace Library.StorageServices
{
    public interface ILibrarian
    {
        public bool Equals(Librarian rawReader, Librarian actuallyReader);
    }
}