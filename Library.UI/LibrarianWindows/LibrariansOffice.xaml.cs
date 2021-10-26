using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library.Services;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows
{
    public partial class LibrariansOffice : Window
    {
        private readonly DataBaseContext _context = DataBaseContextService.GetContext();
        private readonly CsvFileReaderService _csvFileReaderService = new CsvFileReaderService();
        private readonly ReaderService _readerService = new ReaderService();

        private string _messageBoxText;
        
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
                $"Выход из системы", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
            DialogResult = true;

            new MainWindow().Visibility = Visibility.Visible;
        }

        private void OpenExplorerAndGetRecords_OnClick(object sender, RoutedEventArgs e)
        {
            var fileName = FileExplorerService.OpenExplorerAndGetFileName();

            var readersList = _csvFileReaderService.ReadFile<Reader>(fileName);

            if (readersList == null) return;
            _readerService.AddReadersAndSaveDataBaseContext(readersList, out _messageBoxText);

            ReaderGrid.ItemsSource = _context.Readers.ToList();
            MessageBox.Show(_messageBoxText);
        }
    }
}