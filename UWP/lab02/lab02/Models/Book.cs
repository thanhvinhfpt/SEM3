using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }

    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { BookId = 1, Title="Vulpate 1",Author="Future 1", CoverImage="Assets/1.png" });
            books.Add(new Book { BookId = 2, Title = "Vulpate 2", Author = "Future 2", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookId = 3, Title = "Vulpate 3", Author = "Future 3", CoverImage = "Assets/3.png" });
            return books;
        }
    }
}
