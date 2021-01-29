using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNews.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Headline { get; set; }
        public string Subhead { get; set; }
        public string DateLine { get; set; }
        public string Image { get; set; }
    }

    

    public class NewsManager
    {
        private static List<NewsItem> getNewsItems()
        {
            var items = new List<NewsItem>();
            items.Add(new NewsItem { Id = 1, Category = "Financial", Headline = "Lorem IpuSum", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financial.png" });
            items.Add(new NewsItem { Id = 2, Category = "Financial", Headline = "Lorem IpuSum1", Subhead = "doro sit amet 1", DateLine = "Nunc tristique nec 1", Image = "Assets/Financial2.png" });
            items.Add(new NewsItem { Id = 3, Category = "Financial", Headline = "Lorem IpuSum 2", Subhead = "doro sit amet 2", DateLine = "Nunc tristique nec 2", Image = "Assets/Financial3.png" });
            items.Add(new NewsItem { Id = 4, Category = "Financial", Headline = "Lorem IpuSum 3", Subhead = "doro sit amet 3", DateLine = "Nunc tristique nec 3", Image = "Assets/Financial4.png" });
            items.Add(new NewsItem { Id = 5, Category = "Food", Headline = "Lorem IpuSum", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food.png" });
            items.Add(new NewsItem { Id = 6, Category = "Food", Headline = "Lorem IpuSum1", Subhead = "doro sit amet 1", DateLine = "Nunc tristique nec 1", Image = "Assets/Food2.png" });
            items.Add(new NewsItem { Id = 7, Category = "Food", Headline = "Lorem IpuSum 2", Subhead = "doro sit amet 2", DateLine = "Nunc tristique nec 2", Image = "Assets/Food3.png" });
            items.Add(new NewsItem { Id = 8, Category = "Food", Headline = "Lorem IpuSum 3", Subhead = "doro sit amet 3", DateLine = "Nunc tristique nec 3", Image = "Assets/Food4.png" });
            return items;
        }
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = getNewsItems();
            var filteredNewsItems = allItems.Where(p =>p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }
    }
}
