using System;
using System.Windows;
using Library.Logic;

namespace Library.UI.LibrarianWindows
{
    public partial class LibrarianSignInWindow : Window
    {
        private readonly LibrarianService _librarianService = new LibrarianService();
        
        private string _messageBoxText;

        public LibrarianSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInLibrarian_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = NameTextBox.Text.Trim();
                var surname = SurnameTextBox.Text.Trim();
                var middleName = MiddleNameTextBox.Text.Trim();
                var email = EmailTextBox.Text.Trim();
                var phone = PhoneTextBox.Text.Trim();
                var password = PasswordBox.Password.Trim();

                if (!_librarianService.CheckInputData(name, surname, middleName, email, phone, password,
                    out _messageBoxText)) return;
                MessageBox.Show(_messageBoxText);
                DialogResult = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
            }
        }
    }
}