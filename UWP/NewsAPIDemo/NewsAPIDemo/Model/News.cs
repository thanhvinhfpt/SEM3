using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewsAPIDemo.Model
{
    public class News
    {
        public List<Article> articles { get; set; }
        public async static Task<News> GetNews(string p)
        {
            var http = new HttpClient();
            var url = String.Format("https://newsapi.org/v2/top-headlines?q={0}&apiKey=edaf13ccfa1a443085c925ff3792edd9",p);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(News));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (News)serializer.ReadObject(ms);
            return data;
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public int totalResults { get; set; }
       
    }


}
