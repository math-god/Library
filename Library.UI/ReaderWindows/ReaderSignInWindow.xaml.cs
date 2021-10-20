using System;
using System.Windows;
using Library.Services;

namespace Library.UI.ReaderWindows
{
    public partial class ReaderSignInWindow : Window
    {
        private string _messageBoxText;
        private readonly ReaderService _readerService = new ReaderService();

        public ReaderSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInReader_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = NameTextBox.Text.Trim();
                var surname = SurnameTextBox.Text.Trim();
                var middleName = MiddleNameTextBox.Text.Trim();
                var email = EmailTextBox.Text.Trim();
                var phone = PhoneTextBox.Text.Trim();
                var rating = Rating.Text.Trim();
                var password = PasswordBox.Password;

                _readerService.CheckInputData(name, surname, middleName, email, phone, rating, password,
                    out _messageBoxText);

                MessageBox.Show(_messageBoxText);
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
            }
        }
    }
}