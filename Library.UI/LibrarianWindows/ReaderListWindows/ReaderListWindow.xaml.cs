using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library.Service;
using Library.Service.Models;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows.ReaderListWindows
{
    public partial class ReaderListWindow : Window
    {
        private readonly DataBaseContext _context = DataBaseContextService.GetContext();

        private readonly CsvFileReaderService _csvFileReaderService = new CsvFileReaderService();
        private readonly ReaderService _readerService = new ReaderService();
        private readonly SearchFilterService _searchFilterService = new SearchFilterService();

        public ReaderListWindow()
        {
            InitializeComponent();

            ReaderGrid.ItemsSource = _context.Readers.ToList();
        }

        private void GoToAddingNewReaderWindow(object sender, RoutedEventArgs e)
        {
            var addingNewReaderWindow = new AddingReaderWindow();
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
            var fileName = FileExplorerService.OpenExplorerAndGetFileName(FileExplorerService.FileFormat.Csv);

            var readersList = _csvFileReaderService.ReadFile<Reader>(fileName);

            if (readersList.Count == 0) return;
            _readerService.CreateReaders(readersList);

            ReaderGrid.ItemsSource = _context.Readers.ToList();
            MessageBox.Show("Данные были успешно добавлены");
        }
        
        private void DataFiltrationTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ReaderGrid.ItemsSource = _searchFilterService.SearchReader( FiltrationColumnComboBox.Text,
                DataFiltrationTextBox.Text.Trim());
        }
    }
}