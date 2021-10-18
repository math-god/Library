using System;
using System.Windows;
using Library.Models;

namespace Library.LibrarianWindows
{
    public partial class LibrarianSignInWindow : Window
    {
        private readonly Context _context = Context.GetContext();
        
        public LibrarianSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInLibrarian_OnClick(object sender, RoutedEventArgs e)
        {
            Librarian inputData;
            try
            { 
                inputData = new Librarian()
                {
                    Name = NameTextBox.Text.Trim(), Surname = SurnameTextBox.Text.Trim(),
                    MiddleName = MiddleNameTextBox.Text.Trim(), Email = EmailTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(), 
                    Password = PasswordBox.Password.Trim()
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }
            
            foreach (var librarian in _context.Librarians)
            {
                var status = inputData.Equals(librarian);

                if (!status) continue;
                MessageBox.Show("Вход выполнен");
             
                DialogResult = true;
                return;
            }

            MessageBox.Show("Неправильные данные");
        }
    }
}