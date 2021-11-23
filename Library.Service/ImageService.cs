using System;
using System.IO;
using System.Windows.Controls;
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

        public void Base64ToImage(string base64String)
        {
            Guid imageId = Guid.NewGuid();

            var bytes = Convert.FromBase64String(base64String);
            using (var imageFile = new FileStream(
                $"C:\\Users\\danya\\RiderProjects\\PetProjects\\WsrLibrary\\Covers\\{imageId}.jpg",
                FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }
    }
}