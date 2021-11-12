using System;
using System.IO;
using System.Windows.Media.Imaging;


namespace Library.Service
{
    public class ImageService
    {
        public string EncodeImage(string filename)
        {
            var base64 = Convert.ToBase64String(File.ReadAllBytes(filename));

            return base64;
        }
        
        /*public BitmapSource  DecodeBase64(string base64)
        {
            byte[] binaryData = Convert.FromBase64String(base64);

            MemoryStream stream = new MemoryStream(binaryData, 0, binaryData.Length);
            stream.Position = 0;
            
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.StreamSource = stream;
            result.EndInit();
            result.Freeze();
            return result;
        }*/
    }
}