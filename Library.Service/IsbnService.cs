using System.IO;
using System.Net;
using Library.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.Service
{
    public class IsbnService
    {
        public BookDto GetBook(string isbn)
        {
            string webserviceUrl = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&jscmd=details&format=json";


            var webRequest = WebRequest.Create(webserviceUrl);

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json";

                var wr = webRequest.GetResponseAsync().Result;
                var receiveStream = wr.GetResponseStream();
                var reader = new StreamReader(receiveStream);

                var content = reader.ReadToEnd();


                var jsonJObject = JObject.Parse(content);

                var values = jsonJObject.SelectToken($@"$.ISBN:{isbn}.details");

                var bookInfo = JsonConvert.DeserializeObject<BookJsonDto>(values.ToString());

                var bookDto = new BookDto()
                {
                    Title = bookInfo.Title,
                    Genre = bookInfo.Subjects[0],
                    Author = bookInfo.Authors[0].Name,
                    PublicationDate = bookInfo.Publish_Date,
                    Description = bookInfo.Description,
                    Isbn = isbn
                };


                return bookDto;
            }

            return null;
        }
    }
}