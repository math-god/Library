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
                var status = inputData.Equals(librarian);

                if (!status) continue;
                messageBoxText = "Вход выполнен";

                return true;
            }

            messageBoxText = "Неправильные данные";
            return false;
        }
    }
}