using System;
using System.IO;
using System.Net;
using Library.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.Service
{
    public class IsbnService
    {
        /*978-5-93673-265-2*/
        public BookDto GetBook(string isbn)
        {
            string webserviceUrl = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&jscmd=details&format=json";


            var webRequest = WebRequest.Create(webserviceUrl);

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json";

                //Get the response 
                var wr = webRequest.GetResponseAsync().Result;
                var receiveStream = wr.GetResponseStream();
                var reader = new StreamReader(receiveStream);

                string content = reader.ReadToEnd();

                var jsonJObject = JObject.Parse(content);

                var values = jsonJObject.SelectToken($@"$.ISBN:{isbn}.details");

                var bookInfo = JsonConvert.DeserializeObject<BookDto>(values.ToString());

                var bookDto = new BookDto()
                {
                    Title = bookInfo.Title,
                    Genre = bookInfo.Genre,
                    Author = bookInfo.Author,
                    PublicationYear = bookInfo.PublicationYear,
                    Description = bookInfo.Description,
                    Isbn = isbn
                };

                /*var a = json["ISBN:9780980200447"]["details"]["author"].ToString();*/
                
                /*var bookDto = new BookDto()
                {
                    Title = "govno",
                    Genre = json["subjects"][0].ToString(),
                    Author = json["author"].ToString(),
                    Description = json["description"].ToString(),
                    PublicationYear = Convert.ToInt32(json["publish_date"].ToString()),
                    Isbn = Convert.ToInt32(json["isbn_13"].ToString())

                };*/
                
                return bookDto;
            }

            return null;
        }
    }
}