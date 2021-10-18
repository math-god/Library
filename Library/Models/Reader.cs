using System;
using CsvHelper.Configuration.Attributes;

namespace Library.Models
{
    public class Reader
    {
        private string _name;
        private string _surname;
        private string _middleName;
        private string _password;
        private string _banButtonInfo;
        
        [Optional]
        public int Id { get; set; }
        public string Name
        { 
            get => _name;
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Ввод ФИО является обязательным");
                }

                _name = value;
            } 
        }
        public string Surname 
        {
            get => _surname;
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Ввод ФИО является обязательным");
                }
                _surname = value;
            } 
        }
        
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Ввод ФИО является обязательным"); 
                }
                _middleName = value;
            } 
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }

        public string Password
        {
            get => Cryptography.EncodeDecrypt(_password);
            set => _password = Cryptography.EncodeDecrypt(value);
        }

        [Optional]
        public bool IsBanned { get; set; }

        [Optional]
        public string BanButtonInfo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Reader reader)
            {
                return Name == reader.Name && Surname == reader.Surname && MiddleName == reader.MiddleName &&
                       Email == reader.Email && Phone == reader.Phone && Password == reader.Password;
            }
            return false;
        }
    }
}