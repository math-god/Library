using Library.Services;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.Logic
{
    public class LibrarianService
    {
        private DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();
        
        public bool CheckInputData(string name, string surname, string middleName, string email, string phone,
            string password, out string messageBoxText)
        {
            var inputData = new Librarian()
            {
                Name = name,
                Surname = surname,
                MiddleName = middleName,
                Email = email,
                Phone = phone,
                Password = password
            };

            foreach (var librarian in _dataBaseContext.Librarians)
            {
                var status = Equals(inputData, librarian);

                if (!status) continue;
                messageBoxText = "Вход выполнен";

                return true;
            }

            messageBoxText = "Неправильные данные";
            return false;
        }
        
        private static bool Equals(Librarian inputData, Librarian librarian)
        {
            return inputData.Name == librarian.Name &&
                   inputData.Surname == librarian.Surname &&
                   inputData.MiddleName == librarian.MiddleName &&
                   inputData.Email == librarian.Email &&
                   inputData.Phone == librarian.Phone &&
                   inputData.Password == librarian.Password;
        }
    }
}