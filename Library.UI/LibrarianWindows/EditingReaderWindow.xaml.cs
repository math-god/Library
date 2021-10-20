using System;
using System.Windows;
using Library.Services;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows
{
    public partial class EditingReaderWindow : Window
    {
        private readonly ReaderService _readerService = new ReaderService();
        private readonly Reader _reader;

        private string _messageBoxText;

        public EditingReaderWindow(Reader reader = null)
        {
            InitializeComponent();

            PasswordTextBox.Text = reader.Password;
            DataContext = reader;
            _reader = reader;
        }

        private void EditReader_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = NameTextBox.Text.Trim();
                var surname = SurnameTextBox.Text.Trim();
                var middleName = MiddleNameTextBox.Text.Trim();
                var email = EmailTextBox.Text.Trim();
                var phone = PhoneTextBox.Text.Trim();
                var rating = RatingTextBox.Text.Trim();
                var password = PasswordTextBox.Text.Trim();
                var isBanned = (bool) BanCheckBox.IsChecked;
                var banButtonInfo = _reader.IsBanned ? "Заблокирован" : "Разблокирован";

                _readerService.EditReaderAndSaveDataBaseContext(name, surname, middleName, email, phone, rating,
                    password, isBanned, banButtonInfo, out _messageBoxText, _reader);

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