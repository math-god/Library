using System;
using System.Windows;
using Library.Services;

namespace Library.UI.LibrarianWindows
{
    public partial class AddingNewReaderWindow : Window
    {
        private readonly ReaderService _readerService = new ReaderService();

        private string _messageBoxText;

        public AddingNewReaderWindow()
        {
            InitializeComponent();
        }

        private void AddReader_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = NameTextBox.Text.Trim();
                var surname = SurnameTextBox.Text.Trim();
                var middleName = MiddleNameTextBox.Text.Trim();
                var email = EmailTextBox.Text.Trim();
                var phone = PhoneTextBox.Text.Trim();
                var rating = RatingTextBox.Text.Trim();
                var password = PasswordBox.Password;

                _readerService.AddReaderAndSaveDataBaseContext(name, surname, middleName, email, phone, rating,
                    password, out _messageBoxText);

                MessageBox.Show(_messageBoxText);
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }

            DialogResult = true;
        }
    }
}