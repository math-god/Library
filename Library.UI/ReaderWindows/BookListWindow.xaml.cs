using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Library.Service;
using Library.Storage;

namespace Library.UI.ReaderWindows
{
    public partial class BookListWindow : Window
    {
        private readonly DataBaseContext _context = DataBaseContextService.GetContext();

        public BookListWindow()
        {
            InitializeComponent();

            BookGrid.ItemsSource = _context.Books.Where(b => b.IsBanned == false).ToList();
        }
    }
}