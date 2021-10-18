using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library.FileExplorer;
using Library.Models;
using Microsoft.Win32;

namespace Library.LibrarianWindows
{
    public partial class LibrariansOffice : Window
    {
        private readonly Context _context = Context.GetContext();
        public LibrariansOffice()
        {
            InitializeComponent();

            ReaderGrid.ItemsSource = _context.Readers.ToList();
        }

        private void GoToAddingNewReaderWindow(object sender, RoutedEventArgs e)
        {
            var addingNewReaderWindow = new AddingNewReaderWindow();
            addingNewReaderWindow.ShowDialog();
            if (addingNewReaderWindow.DialogResult == true)
            {
                ReaderGrid.ItemsSource = _context.Readers.ToList();
            }
        }
        
        private void GoToEditingReaderWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var editingReaderWindow = new EditingReaderWindow((sender as Button)?.DataContext as Reader);
            editingReaderWindow.ShowDialog();
            if (editingReaderWindow.DialogResult == true)
            {
                ReaderGrid.ItemsSource = _context.Readers.ToList();
            }
        }

        private void SignOutButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите выйти?",
                $"Выход из системы", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DialogResult = true;

                new MainWindow().Visibility = Visibility.Visible;
            }
        }

        private void OpenExplorer_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog {Filter = "CSV files (*.csv)|*.csv"};

            if (openFileDialog.ShowDialog() != true) return;
            var fileName = openFileDialog.FileName;
            var readersList = CsvFileService.Open(fileName);

            if (readersList == null) return;
            _context.Readers.AddRange(readersList);
            _context.SaveChanges();
            ReaderGrid.ItemsSource = _context.Readers.ToList();
            MessageBox.Show("Данные были успешно добавлены");
        }
    }
}