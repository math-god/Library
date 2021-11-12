using System.Windows;
using Library.Service;
using Library.Service.Models;
using Library.Service;

namespace Library.UI.ReaderWindows
{
    public partial class ReaderSignInWindow : Window
    {
        private readonly ReaderService _readerService = new ReaderService();

        public ReaderSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInReader_OnClick(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text.Trim();
            var phone = PhoneTextBox.Text.Trim();
            var password = PasswordBox.Password;

            var userDto = new UserDto()
            {
                Email = email,
                Phone = phone,
                Password = password
            };

            if (_readerService.CheckInputData(userDto) == true)
            {
                MessageBox.Show("Вход выполнен");
                DialogResult = true;
            }
            else if (_readerService.CheckInputData(userDto) == null)
            {
                MessageBox.Show("Данный читатель заблокирован");
            }
            else
            {
                MessageBox.Show("Неправильные данные");
            }
        }
    }
}