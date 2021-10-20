using Library.Models;

namespace Library.StorageServices
{
    public interface IReader
    {
        public bool Equals(Reader rawReader, Reader actuallyReader);
    }
}