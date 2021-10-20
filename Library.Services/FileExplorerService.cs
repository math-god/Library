using Microsoft.Win32;

namespace Library.Services
{
    public class FileExplorerService
    {
        public static string OpenExplorerAndGetFileName()
        {
            var openFileDialog = new OpenFileDialog {Filter = "CSV files (*.csv)|*.csv"};

            if (openFileDialog.ShowDialog() != true) return null;
            var fileName = openFileDialog.FileName;
            return fileName;
        }
    }
}