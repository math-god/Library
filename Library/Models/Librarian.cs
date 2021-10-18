using System;

namespace Library.Models
{
    public class Librarian
    {
        private string _name;
        private string _surname;
        private string _middleName;
        
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
        public string Password { get; set; }

        /*private string CheckFIO(string value)
        {
            if (value == string.Empty)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }

            return value;
        }*/
        public override bool Equals(object? obj)
        {
            if (obj is Librarian librarian)
            {
                return Name == librarian.Name && Surname == librarian.Surname && MiddleName == librarian.MiddleName &&
                       Email == librarian.Email && Phone == librarian.Phone && Password == librarian.Password;
            }
            return false;
        }
    }
}