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
                var password = PasswordBox.Password;

                if (!_readerService.CheckInputData(name, surname, middleName, email, phone, password,
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