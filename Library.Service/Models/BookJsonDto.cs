using System.Collections.Generic;
using Newtonsoft.Json;

namespace Library.Service.Models
{
    public class BookJsonDto
    {
        public string Title { get; set; }
        public string[] Subjects { get; set; }
        public List<Author> Authors { get; set; }
        public string Publish_Date { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
    }

    public class Author
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}