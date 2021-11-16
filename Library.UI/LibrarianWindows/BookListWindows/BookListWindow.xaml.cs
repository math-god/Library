using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Library.Service;
using Library.Storage;
using Library.Storage.EntityModels;

namespace Library.UI.LibrarianWindows.BookListWindows
{
    public partial class BookListWindow : Window
    {
        private readonly DataBaseContext _context = DataBaseContextService.GetContext();

        public BookListWindow()
        {
            InitializeComponent();

            BookGrid.ItemsSource = _context.Books.ToList();
        }

        private void GoToBookDescriptionWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var bookDescriptionWindow = new BookDescriptionWindow((sender as Button)?.DataContext as Book);
            bookDescriptionWindow.ShowDialog();
            if (bookDescriptionWindow.DialogResult == true)
            {
                BookGrid.ItemsSource = _context.Books.ToList();
            }
        }

        private void GoToAddingBookWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var addingBookWindow = new AddingBookWindow();
            addingBookWindow.ShowDialog();
            if (addingBookWindow.DialogResult == true)
            {
                BookGrid.ItemsSource = _context.Books.ToList();
            }
        }

        private void GoToEditingBookWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var editingBookWindow = new EditingBookWindow((sender as Button)?.DataContext as Book);
            editingBookWindow.ShowDialog();
            if (editingBookWindow.DialogResult == true)
            {
                BookGrid.ItemsSource = _context.Books.ToList();
            }
        }

        private void GoToAddingBookByIsbn_OnClick(object sender, RoutedEventArgs e)
        {
            var addingBookByIsbnWindow = new AddingBookByIsbnWindow();
            addingBookByIsbnWindow.ShowDialog();
            if (addingBookByIsbnWindow.DialogResult == true)
            {
                BookGrid.ItemsSource = _context.Books.ToList();
            }
        }
    }
}