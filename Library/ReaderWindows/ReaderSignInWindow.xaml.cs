using System;
using System.Windows;
using Library.Models;

namespace Library.ReaderWindows
{
    public partial class ReaderSignInWindow : Window
    {
        private readonly Context _context = Context.GetContext();

        public ReaderSignInWindow()
        {
            InitializeComponent();
        }

        private void SignInReader_OnClick(object sender, RoutedEventArgs e)
        {
            Reader inputData;
            try
            {
                inputData = new Reader()
                {
                    Name = NameTextBox.Text.Trim(), Surname = SurnameTextBox.Text.Trim(),
                    MiddleName = MiddleNameTextBox.Text.Trim(), Email = EmailTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(), Rating = Rating.Text.Trim(),
                    Password = PasswordBox.Password
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }

            foreach (var reader in _context.Readers)
            {
                reader.Id = 0;

                var status = inputData.Equals(reader);

                if (!status) continue;
                if (reader.IsBanned)
                {
                    MessageBox.Show("Данный читатель заблокирован");
                    return;
                }
                MessageBox.Show("Вход выполенен");
                DialogResult = true;
                return;
            }

            MessageBox.Show("Неправильные данные");
        }
    }
}