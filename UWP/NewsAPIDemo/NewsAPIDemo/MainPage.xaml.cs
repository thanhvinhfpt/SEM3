using NewsAPIDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewsAPIDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Article> listNews;

        public MainPage()
        {
            this.InitializeComponent();
            listNews = new ObservableCollection<Article>();
            InitNews();

        }

        private async void InitNews()
        {
            
                
                var list = await News.GetNews("Trum") as News;
                titleTextBlock.Text = list.articles[0].title;
                contentTextBlock.Text = list.articles[0].content;
                /*Image img = new Image();*/
             /*   img.Source = new BitmapImage(new Uri(myNews.articles[0].urlToImage));*/
              /*  resourceImage.Source = new BitmapImage(new Uri(myNews.articles[0].urlToImage, UriKind.Relative))*/;
                /*list.articles.ForEach(it =>
                {
                    it.title = "acn";
                    it.content = it.content;
                    listNews.Add(it);
                });
                titleTextBlock.Text = list.articles[0].title;
                contentTextBlock.Text = list.articles[0].content;
                listNews.RemoveAt(0);*/
           
        }

        
    }
}
