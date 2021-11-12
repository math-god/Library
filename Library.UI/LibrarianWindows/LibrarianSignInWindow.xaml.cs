using System;
using System.Windows;
using Library.Service;
using Library.Service.Models;
using Library.Service;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows
{
    public partial class LibrarianSignInWindow : Window
    {
        private readonly LibrarianService _librarianService = new LibrarianService();


        public LibrarianSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInLibrarian_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = EmailTextBox.Text.Trim();
                var phone = PhoneTextBox.Text.Trim();
                var password = PasswordBox.Password.Trim();

                /*var dtoService = new DtoService<Librarian>(new Librarian());*/
                var userDto = new UserDto()
                {
                    Email = email,
                    Phone = phone,
                    Password = password
                };

                if (_librarianService.CheckInputData(userDto))
                {
                    MessageBox.Show("Вход выполнен");
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Неправильные данные");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
            }
        }
    }
}