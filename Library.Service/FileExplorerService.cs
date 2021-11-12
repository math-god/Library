using Microsoft.Win32;

namespace Library.Service
{
    public class FileExplorerService
    {
        public enum FileFormat
        {
            Csv,
            Jpg
        }
        
        public static string OpenExplorerAndGetFileName(FileFormat fileFormat)
        {
            var openFileDialog = new OpenFileDialog();
            
            if (fileFormat == FileFormat.Csv)
            {
                openFileDialog = new OpenFileDialog {Filter = "CSV files (*.csv)|*.csv"};
            }
            else if (fileFormat == FileFormat.Jpg)
            {
                openFileDialog = new OpenFileDialog {Filter = "JPG files (*.jpg)|*.jpg"};
            }


            if (openFileDialog.ShowDialog() != true) return null;
            var fileName = openFileDialog.FileName;
            return fileName;
        }
    }
}