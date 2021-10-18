using System;
using System.Windows;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.LibrarianWindows
{
    public partial class EditingReaderWindow : Window
    {
        private readonly Context _context = Context.GetContext();
        private Reader _reader;
        public EditingReaderWindow(Reader reader = null)
        {
            InitializeComponent();
            
            PasswordTextBox.Text = reader.Password;
            DataContext = reader;
            _reader = reader;
        }

        private void EditReader_OnClick(object sender, RoutedEventArgs e)
        {
            Reader inputData;
            try
            {
                _reader.Name = NameTextBox.Text.Trim();
                _reader.Surname = SurnameTextBox.Text.Trim();
                _reader.MiddleName = MiddleNameTextBox.Text.Trim();
                _reader.Email = EmailTextBox.Text.Trim();
                _reader.Rating = RatingTextBox.Text.Trim();
                _reader.Phone = PhoneTextBox.Text.Trim();
                _reader.Password = PasswordTextBox.Text.Trim();
                _reader.IsBanned = (bool) BanCheckBox.IsChecked;
                _reader.BanButtonInfo = _reader.IsBanned ? "Заблокирован" : "Разблокирован";
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }
            
            _context.SaveChanges();

            MessageBox.Show("Профиль читателя изменен");

            DialogResult = true;
        }

        /*private void ShowPasswordButton_OnClick(object sender, RoutedEventArgs e)
        {
            var val = PasswordBox.Visibility;
            PasswordBox.Visibility = PasswordTextBox.Visibility;
            PasswordTextBox.Visibility = val;
        }*/
    }
}
