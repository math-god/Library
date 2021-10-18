using System;
using System.Windows;
using Library.Models;

namespace Library.LibrarianWindows
{
    public partial class AddingNewReaderWindow : Window
    {
        private readonly Context _context = Context.GetContext();
        public AddingNewReaderWindow()
        {
            InitializeComponent();
        }
        
        private void AddReader_OnClick(object sender, RoutedEventArgs e)
        {
            Reader inputData;
            try
            {
                inputData = new Reader()
                {
                    Name = NameTextBox.Text.Trim(), Surname = SurnameTextBox.Text.Trim(),
                    MiddleName = MiddleNameTextBox.Text.Trim(), Email = EmailTextBox.Text.Trim(),
                    Rating = RatingTextBox.Text.Trim(), Phone = PhoneTextBox.Text.Trim(), 
                    Password = PasswordBox.Password, BanButtonInfo = "Разблокирован"
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Ввод ФИО является обязательным");
                return;
            }
            
            _context.Readers.Add(inputData);
            _context.SaveChanges();
            
            
            MessageBox.Show("Новый читатель добавлен");

            DialogResult = true;
        }
    }
}