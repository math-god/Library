using System.Collections.Generic;
using Library.Service.Models;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.Service
{
    public class ReaderService
    {
        private readonly DataBaseContext _dataBaseContext = DataBaseContextService.GetContext();

        public bool? CheckInputData(UserDto userDto)
        {
            foreach (var reader in _dataBaseContext.Readers)
            {
                var status = Equals(userDto, reader);

                if (!status) continue;
                if (reader.IsBanned) return null;
                return true;
            }

            return false;
        }

        public void CreateReader(string name, string surname, string middleName, string email,
            string phone, string rating, string password)
        {
            var inputData = new Reader()
            {
                Name = name,
                Surname = surname,
                MiddleName = middleName,
                Email = email,
                Phone = phone,
                Rating = rating,
                Password = CryptographyService.EncodeDecrypt(password),
            };

            _dataBaseContext.Readers.Add(inputData);
            _dataBaseContext.SaveChanges();
        }

        public void CreateReaders(List<Reader> readersList)
        {
            if (readersList == null)
            {
                return;
            }
            _dataBaseContext.Readers.AddRange(readersList);
            _dataBaseContext.SaveChanges();
        }

        public void EditReader(string name, string surname, string middleName, string email,
            string phone, string rating, string password, bool isBanned, Reader reader)
        {
            reader.Name = name;
            reader.Surname = surname;
            reader.MiddleName = middleName;
            reader.Email = email;
            reader.Rating = rating;
            reader.Phone = phone;
            reader.Password = CryptographyService.EncodeDecrypt(password);
            reader.IsBanned = isBanned;

            _dataBaseContext.SaveChanges();
        }

        private static bool Equals(UserDto inputData, Reader reader)
        {
            return inputData.Email == reader.Email &&
                   inputData.Phone == reader.Phone &&
                   inputData.Password == CryptographyService.EncodeDecrypt(reader.Password);
        }
    }
}