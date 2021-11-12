using System.Windows;

namespace Library.UI.ReaderWindows
{
    public partial class ReadersOfficeWindow : Window
    {
        public ReadersOfficeWindow()
        {
            InitializeComponent();
        }
        
        private void GoToBookListWindow_OnClick(object sender, RoutedEventArgs e)
        {
            new BookListWindow().ShowDialog();
        }
    }
}