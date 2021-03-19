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

using NEWSAPI.Models;
using Windows.UI.Xaml.Media.Imaging;

namespace NEWSAPI
{
    public sealed partial class ArticleView : Page
    {
        public ArticleView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var article = e.Parameter as Article;

            Image.Source = new BitmapImage(new Uri(article.urlToImage, UriKind.Absolute));
            Author.Text = article.author;
            Title.Text = article.title;
            Description.Text = article.description;

            base.OnNavigatedTo(e);
        }

        private void BtnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
