using System;
using System.Windows;

namespace Library.UI.LibrarianWindows
{
    public partial class LibrarianSignInWindow : Window
    {

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
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }
        }
    }
}