using Library.Models;

#nullable enable
namespace Library.StorageServices
{
    public abstract class EntityModelsService : ILibrarian, IReader
    {
        /*public override bool Equals(object? obj)
        {
            if (obj is Librarian librarian)
            {
                return Name == librarian.Name && Surname == librarian.Surname && MiddleName == librarian.MiddleName &&
                       Email == librarian.Email && Phone == librarian.Phone && Password == librarian.Password;
            }

            return false;
        }*/

        bool IReader.Equals(Reader rawLibrarian, Reader actuallyLibrarian)
        {
            return rawLibrarian.Name == actuallyLibrarian.Name && rawLibrarian.Surname == actuallyLibrarian.Surname &&
                   rawLibrarian.MiddleName == actuallyLibrarian.MiddleName &&
                   rawLibrarian.Email == actuallyLibrarian.Email && rawLibrarian.Phone == actuallyLibrarian.Phone &&
                   rawLibrarian.Password == actuallyLibrarian.Password;
        }

        bool ILibrarian.Equals(Librarian rawLibrarian, Librarian actuallyLibrarian)
        {
            return rawLibrarian.Name == actuallyLibrarian.Name && rawLibrarian.Surname == actuallyLibrarian.Surname &&
                   rawLibrarian.MiddleName == actuallyLibrarian.MiddleName &&
                   rawLibrarian.Email == actuallyLibrarian.Email && rawLibrarian.Phone == actuallyLibrarian.Phone &&
                   rawLibrarian.Password == actuallyLibrarian.Password;
        }
    }
}