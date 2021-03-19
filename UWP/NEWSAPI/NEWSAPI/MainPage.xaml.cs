using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Collections.ObjectModel;
using NEWSAPI.Models;
using SQLitePCL;

namespace NEWSAPI
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Article> Articles;

        public SQLiteConnection conn = new SQLiteConnection("News.db");
        public MainPage()
        {
            this.InitializeComponent();
            Articles = new ObservableCollection<Article>();
            GetAR("tesla", "2021-02-18", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
            SQLiteConnection conn = new SQLiteConnection("News.db");
            string sql = @"CREATE TABLE IF NOT EXISTS News (Id Integer Primary Key AutoIncrement Not null
                        , urlLink varchar(255)
                        );";
            SQLiteStatement statment = (SQLiteStatement)conn.Prepare(sql);
            statment.Step();
            
        }

        private async void GetAR(string q, string from, string SortBy, string ApiKey)
        {
            //var url = string.Format("https://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, SortBy, ApiKey);
            var url = string.Format("http://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, SortBy, ApiKey);
            var news = await New.GetNew(url) as RootObject;
            news.articles.ForEach(n => {
                Articles.Add(n);
            });
        }

        private void View_ItemClick(object sender, ItemClickEventArgs e)
        {
            Article ar = e.ClickedItem as Article;
            Frame.Navigate(typeof(ArticleView), ar);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Articles.Clear();
            string q = search.Text;
            if(q != "")
            {
                GetAR(q, "2021-02-18", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
            }
            else
            {
                GetAR("tesla", "2021-02-18", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
            }
            

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                Articles.Clear();
                GetAR("tesla", "2021-02-18", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
                TitleTextBlock.Text = "Home News";
            }
            else if (Favorite.IsSelected)
            {
                Articles.Clear();
                GetAR("bitcoin", "2021-02-18", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
                TitleTextBlock.Text = "Favorite News";
                
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Home.IsSelected = true;
        }

        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var myTextBlock = (TextBox)this.FindName("check");
            string a = myTextBlock.Text;
            Console.WriteLine(a);

        }

       
    }
}
