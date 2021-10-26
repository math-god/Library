using System.Collections.Generic;
using System.Windows.Documents;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.Services
{
    public class ReaderService
    {
        private readonly DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();

        public bool CheckInputData(string name, string surname, string middleName, string email, string phone,
            string password, out string messageBoxText)
        {
            var inputData = new Reader()
            {
                Name = name,
                Surname = surname,
                MiddleName = middleName,
                Email = email,
                Phone = phone,
                Password = password
            };

            foreach (var reader in _dataBaseContext.Readers)
            {
                var status = Equals(inputData, reader);

                if (!status) continue;
                if (reader.IsBanned)
                {
                    messageBoxText = "Данный читатель заблокирован";
                    return false;
                }

                messageBoxText = "Вход выполенен";
                return true;
            }

            messageBoxText = "Неправильные данные";
            return false;
        }

        public void AddReaderAndSaveDataBaseContext(string name, string surname, string middleName, string email,
            string phone, string rating, string password, out string messageBoxText)
        {
            var inputData = new Reader()
            {
                Name = name,
                Surname = surname,
                MiddleName = middleName,
                Email = email,
                Phone = phone,
                Rating = rating,
                Password = password,
                BanButtonInfo = "Разблокирован"
            };

            _dataBaseContext.Readers.Add(inputData);
            _dataBaseContext.SaveChanges();

            messageBoxText = "Данные были успешно добавлены";
        }

        public void AddReadersAndSaveDataBaseContext(List<Reader> readersList, out string messageBoxText)
        {
            _dataBaseContext.Readers.AddRange(readersList);
            _dataBaseContext.SaveChanges();
            messageBoxText = "Данные были успешно добавлены";
        }

        public void EditReaderAndSaveDataBaseContext(string name, string surname, string middleName, string email,
            string phone, string rating, string password, bool isBanned, string banButtonInfo,
            out string messageBoxText, Reader reader)
        {
            reader.Name = name;
            reader.Surname = surname;
            reader.MiddleName = middleName;
            reader.Email = email;
            reader.Rating = rating;
            reader.Phone = phone;
            reader.Password = password;
            reader.IsBanned = isBanned;
            reader.BanButtonInfo = banButtonInfo;

            _dataBaseContext.SaveChanges();

            messageBoxText = "Данные были успешно изменены";
        }

        private static bool Equals(Reader inputData, Reader reader)
        {
            return inputData.Name == reader.Name &&
                   inputData.Surname == reader.Surname &&
                   inputData.MiddleName == reader.MiddleName &&
                   inputData.Email == reader.Email &&
                   inputData.Phone == reader.Phone &&
                   inputData.Password == reader.Password;
        }
    }
}